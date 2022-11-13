namespace Api.Services.Employee;

public class EmployeeController : MediaControllerBase<IEmployeeService>, IEmployeeService
{
    public EmployeeController(IEmployeeService service) : base(service)
    {
    }
}