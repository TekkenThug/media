using Api.Data;
using Api.Data.User;

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

}