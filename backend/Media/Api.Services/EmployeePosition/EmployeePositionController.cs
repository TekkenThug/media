namespace Api.Services.EmployeePosition;

public class EmployeePositionController : MediaControllerBase<MediaServiceBase>, IEmployeePositionService
{
    public EmployeePositionController(MediaServiceBase service) : base(service)
    {
    }
}