using Api.Db;

namespace Api.Services.EmployeePosition;

public class EmployeePositionService : MediaServiceBase, IEmployeePositionService
{
    public EmployeePositionService(ApplicationContext context) : base(context)
    {
    }
}