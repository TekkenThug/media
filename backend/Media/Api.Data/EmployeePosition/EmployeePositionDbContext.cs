using Microsoft.EntityFrameworkCore;

namespace Api.Data.EmployeePosition;

public readonly struct EmployeePositionDbContext : IEntityDbContext<EmployeePositionOrm>
{
    public DbSet<EmployeePositionOrm> EmployeePositions { get; }

    public EmployeePositionDbContext (DbContext db)
    {
        this.EmployeePositions = db.Set<EmployeePositionOrm>();
    }
    
    public async Task<EmployeePositionOrm> GetModel(int modelId)
    {
        return await GetModels().FirstOrDefaultAsync(x=>x.Id == modelId);
    }

    public IQueryable<EmployeePositionOrm> GetModels()
    {
        return this.EmployeePositions;
    }
}