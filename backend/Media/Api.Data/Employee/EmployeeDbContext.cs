using Microsoft.EntityFrameworkCore;

namespace Api.Data.Employee;

public readonly struct EmployeeDbContext : IEntityDbContext<EmployeeOrm>
{
    public DbSet<EmployeeOrm> Employees { get; }

    public EmployeeDbContext(DbContext db)
    {
        this.Employees = db.Set<EmployeeOrm>();
    }
    
    public EmployeeOrm GetModel(int modelId)
    {
        return GetModels().FirstOrDefault(x => x.Id == modelId);
    }

    public IQueryable<EmployeeOrm> GetModels()
    {
        return Employees.Include(x => x.Position);
    }
}