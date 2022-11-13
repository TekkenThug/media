using Api.Db;

namespace Api.Services.User;

public class UserService : MediaServiceBase, IUserService
{
    public UserService(ApplicationContext context) : base(context)
    {
    }
}