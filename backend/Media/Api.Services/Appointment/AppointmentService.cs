using Api.Data;
using Api.Data.Appointment;

namespace Api.Services.Appointment;

public class AppointmentService  : DbServiceEntityBase<AppointmentOrm, AppointmentDbContext>, IAppointmentService
{
    public AppointmentService(MediaDbContext context) : base(context)
    {
    }

    protected override AppointmentDbContext CreateDbContext()
    {
        return new AppointmentDbContext(this.Context);
    }
}