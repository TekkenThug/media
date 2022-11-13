using Microsoft.EntityFrameworkCore;

namespace Api.Data.Appointment;

public readonly struct AppointmentDbContext : IEntityDbContext<AppointmentOrm>
{
    public DbSet<AppointmentOrm> Appointments { get; }

    public AppointmentDbContext(DbContext db)
    {
        this.Appointments = db.Set<AppointmentOrm>();
    }
    
    public AppointmentOrm GetModel(int modelId)
    {
        return GetModels().FirstOrDefault(x => x.Id == modelId);
    }

    public IQueryable<AppointmentOrm> GetModels()
    {
        return Appointments
            .Include(x => x.Admin)
            .Include(x => x.Employee)
            .Include(x => x.EmployeePosition);
    }
}