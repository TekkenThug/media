using Api.Data.User;
using Api.Data.User.Operations.BlockUser;
using Api.Data.User.Operations.UserAuthentication;
using Api.Data.User.Operations.UserRegister;

namespace Api.Services.User;

public interface IUserService : IServiceBase<UserOrm>
{
    Task<UserRegisterResponse> Register(UserRegisterRequest request);
    
    Task<UserAuthenticationResponse> Authentication(UserAuthenticationRequest request);

    Task<BlockUserResponse> BlockUser(BlockUserRequest request);
}