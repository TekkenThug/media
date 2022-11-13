using Api.Data.User;

namespace Api.Services.User;

public class UserController : MediaControllerBase<IUserService>, IUserService
{
    public UserController(IUserService service) : base(service)
    {
    }
}