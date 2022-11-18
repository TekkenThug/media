using Api.Data;

namespace Api.Services;

public abstract class DbServiceEntityBase<TOrmModel, TDbContext> 
    where TOrmModel : class, IEntityOrm, new() 
    where TDbContext : IEntityDbContext<TOrmModel>
{
    protected readonly MediaDbContext Context;
    
    public DbServiceEntityBase(MediaDbContext context)
    {
        Context = context;
    }

    protected abstract TDbContext CreateDbContext();
}