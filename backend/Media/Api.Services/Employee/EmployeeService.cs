using Api.Db;

namespace Api.Services.Employee;

public class EmployeeService : MediaServiceBase, IEmployeeService
{
    public EmployeeService(ApplicationContext context) : base(context)
    {
    }
}