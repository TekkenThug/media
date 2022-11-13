namespace Api.Services.Employee;

public class EmployeeController : MediaControllerBase<EmployeeService>, IEmployeeService
{
    public EmployeeController(EmployeeService service) : base(service)
    {
    }
}