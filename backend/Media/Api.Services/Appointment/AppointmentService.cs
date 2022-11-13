using Api.Db;

namespace Api.Services.Appointment;

public class AppointmentService : MediaServiceBase, IAppointmentService
{
    public AppointmentService(ApplicationContext context) : base(context)
    {
    }
}