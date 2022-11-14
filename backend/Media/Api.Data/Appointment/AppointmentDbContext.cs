using Microsoft.EntityFrameworkCore;

namespace Api.Data.Appointment;

public readonly struct AppointmentDbContext : IEntityDbContext<AppointmentOrm>
{
    public DbSet<AppointmentOrm> Appointments { get; }

    public AppointmentDbContext(DbContext db)
    {
        this.Appointments = db.Set<AppointmentOrm>();
    }
    
    public async Task<AppointmentOrm> GetModel(int modelId)
    {
        return await GetModels().FirstOrDefaultAsync(x => x.Id == modelId);
    }

    public IQueryable<AppointmentOrm> GetModels()
    {
        return Appointments
            .Include(x => x.Admin)
            .Include(x => x.Employee)
            .Include(x => x.EmployeePosition);
    }
}