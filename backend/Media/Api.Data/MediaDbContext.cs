using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

public sealed class MediaDbContext : DbContext
{
    private readonly string _connectionString;
    private readonly DbConnection _connection;

    public MediaDbContext(DbConnection connection) => _connection = connection;

    public MediaDbContext(string connectionString) => _connectionString = connectionString;

    public MediaDbContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.EnableSensitiveDataLogging();

            //optionsBuilder.UseNpgsql(_connection, x => x.UseRowNumberForPaging());
        }
    }
}