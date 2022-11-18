using System.Diagnostics;
using Api.Data.Migrations;
using Api.Data.Migrations.Migrations;
using Api.Host.Configuration;
using StructureMap;

namespace Api.Host;

public class MediaRuntime
{
    private readonly CancellationTokenSource _cancellationTokenSource;

    public IContainer Container { get; }

    public MediaRuntime(CancellationTokenSource cancellationTokenSource)
    {
        _cancellationTokenSource = cancellationTokenSource;
        
        MediaBootstrapper.Instance.Bootstrap();

        this.Container = MediaBootstrapper.Instance.Container;
    }

    public void Start()
    {
        try
        {
            var configuration = this.Container.GetInstance<MediaConfiguration>();

            MigrateDatabase(configuration);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            
            Stop();    
        }
    }

    public void Stop()
    {
        try
        {
            _cancellationTokenSource.Cancel();

            // Даем немного времени на отработку Cancel во всех запущенных задачах.
            Thread.Sleep(TimeSpan.FromSeconds(value: 5));
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            
            Process.GetCurrentProcess().Kill();
        }
    }

    private static void MigrateDatabase(MediaConfiguration configuration)
    {
        var migrator = new Migrator(configuration.ConnectionString, typeof(M000_EmployeePositions).Assembly);
        migrator.MigrateUp();
    }
}