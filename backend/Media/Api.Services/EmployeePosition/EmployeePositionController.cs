namespace Api.Services.EmployeePosition;

public class EmployeePositionController : MediaControllerBase<IEmployeePositionService>, IEmployeePositionService
{
    public EmployeePositionController(IEmployeePositionService service) : base(service)
    {
    }
}