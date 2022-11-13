namespace Api.Services.User;

public class UserController : MediaControllerBase<UserService>, IUserService
{
    public UserController(UserService service) : base(service)
    {
    }
}