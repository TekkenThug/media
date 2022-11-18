using Api.Data;
using Api.Data.EmployeePosition;

namespace Api.Services.EmployeePosition;

public class EmployeePositionService : 
    DbServiceEntityBase<EmployeePositionOrm, EmployeePositionDbContext>,
    IEmployeePositionService
{
    public EmployeePositionService(MediaDbContext context) : base(context)
    {
    }

    protected override EmployeePositionDbContext CreateDbContext()
    {
        return new EmployeePositionDbContext(this.Context);
    }
}