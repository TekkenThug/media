using Api.Data.User.Operations.UserAuthentication;
using Api.Data.User.Operations.UserRegister;

namespace Api.Services.User;

public interface IUserService
{
    Task<UserRegisterResponse> Register(UserRegisterRequest request);
    
    Task<UserAuthenticationResponse> Authentication(UserAuthenticationRequest request);
}