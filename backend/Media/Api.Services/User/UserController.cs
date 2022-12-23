using Api.Data.User.Operations.UserAuthentication;
using Api.Data.User.Operations.UserRegister;
using Microsoft.AspNetCore.Mvc;

namespace Api.Services.User;

public class UserController : MediaControllerBase<IUserService>, IUserService
{
    public UserController(IUserService service) : base(service)
    {
    }

    [HttpPost]
    [Route("register")]
    public Task<UserRegisterResponse> Register(UserRegisterRequest request) => this.Service.Register(request);

    [HttpPost]
    [Route("auth")]
    public Task<UserAuthenticationResponse> Authentication(UserAuthenticationRequest request) =>
        this.Service.Authentication(request);
}