﻿using System.Text;
using Api.Data;
using Api.Data.Shared;
using Api.Data.User;
using Api.Data.User.Operations.UserAuthentication;
using Api.Data.User.Operations.UserRegister;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.User;

public class UserService : DbServiceEntityBase<UserOrm, UserDbContext>, IUserService
{
    public UserService(MediaDbContext context) : base(context)
    {
    }

    protected override UserDbContext CreateDbContext()
    {
        return new UserDbContext(this.Context);
    }

    public async Task<UserRegisterResponse> Register(UserRegisterRequest request)
    {
        var result = new UserRegisterResponse();

        var dbContext = CreateDbContext();

        result.Error.UserWithSameEmailAlreadyExist = await dbContext.Users.AnyAsync(x => x.Email.Equals(request.Email));
        result.Error.UserWithSameLoginAlreadyExist = await dbContext.Users.AnyAsync(x => x.Login.Equals(request.Login));

        if (result.Error.UserWithSameEmailAlreadyExist || result.Error.UserWithSameLoginAlreadyExist)
        {
            return result;
        }

        var user = new UserOrm
        {
            Status  = UserStatus.Active,
            Login = request.Login,
            Password = Encoding.UTF8.GetBytes(request.Password),
            LastName = request.LastName,
            FirstName = request.FirstName,
            Surname = request.Surname,
            Email = request.Email,
            RegistrationDateTime = DateTimeOffset.Now
        };

        await InvokeAsyncOperation(() => dbContext.Users.AddAsync(user), result);

        return result;
    }

    public async Task<UserAuthenticationResponse> Authentication(UserAuthenticationRequest request)
    {
        var result = new UserAuthenticationResponse();
        
        var dbContext = CreateDbContext();

        UserOrm? user = await dbContext.Users.FirstOrDefaultAsync(x =>
            x.Email.Equals(request.EmailOrLogin) || x.Login.Equals(request.EmailOrLogin));

        if (user == null)
        {
            result.Error.UserNotFound = true;

            return result;
        }

        string userPassword = Encoding.UTF8.GetString(user.Password);

        if (!userPassword.Equals(request.Password))
        {
            result.Error.InvalidPassword = true;

            return result;
        }

        result.IsSucceeded = true;

        return result;
    }
}