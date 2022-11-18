namespace Api.Services.Appointment;

public class AppointmentController : MediaControllerBase<IAppointmentService>, IAppointmentService
{
    public AppointmentController(IAppointmentService service) : base(service)
    {
    }
}