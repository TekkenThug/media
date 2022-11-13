namespace Api.Services.Appointment;

public class AppointmentController : MediaControllerBase<AppointmentService>, IAppointmentService
{
    public AppointmentController(AppointmentService service) : base(service)
    {
    }
}