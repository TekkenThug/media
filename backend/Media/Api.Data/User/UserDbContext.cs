using Microsoft.EntityFrameworkCore;

namespace Api.Data.User;

public readonly struct UserDbContext : IEntityDbContext<UserOrm>
{
    public DbSet<UserOrm> Users { get; }

    public UserDbContext(DbContext db)
    {
        this.Users = db.Set<UserOrm>();
    }
    
    public async Task<UserOrm> GetModel(int modelId)
    {
        return await GetModels().FirstOrDefaultAsync(x => x.Id == modelId);
    }

    public IQueryable<UserOrm> GetModels()
    {
        return this.Users.Include(x=>x.Moderator);
    }
}