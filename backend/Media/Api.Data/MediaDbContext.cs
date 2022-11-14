using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public sealed class MediaDbContext : DbContext
{
    private readonly string _connectionString;

    public MediaDbContext(string connectionString) => _connectionString = connectionString;

    public MediaDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            optionsBuilder.UseNpgsql(_connectionString);
        }
    }
}