using Api.Contracts.Appointment.Model;
using Api.Contracts.Article.Model;
using Api.Contracts.Comment.Model;
using Api.Contracts.Employee.Model;
using Api.Contracts.EmployeePosition.Model;
using Api.Contracts.User.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Db;

public sealed class ApplicationContext : DbContext
{
    public DbSet<AppointmentModelDto> Appointments { get; set; } = null!;
    
    public DbSet<ArticleModelDto> Articles { get; set; } = null!;
    
    public DbSet<CommentModelDto> Comments { get; set; } = null!;
    
    public DbSet<EmployeeModelDto> Employees { get; set; } = null!;
    
    public DbSet<EmployeePositionModelDto> EmployeePositions { get; set; } = null!;
    
    public DbSet<UserModelDto> Users { get; set; } = null!;

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}