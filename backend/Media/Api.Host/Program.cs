using Topshelf;

namespace Api.Host;

public static class Program
{
    public static void Main(string[] args)
    {
        var cancellationTokenSource = new CancellationTokenSource();
        IHost aspNetCoreHost = null;

        HostFactory.Run(
            config =>
            {
                config.Service<MediaRuntime>(
                    service =>
                    {
                        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

                        service.ConstructUsing(() => new MediaRuntime(cancellationTokenSource));

                        service.WhenStarted(
                            runtime =>
                            {
                                aspNetCoreHost = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                                    .UseServiceProviderFactory(
                                        new StructureMapContainerBuilderFactory(runtime.Container))
                                    .ConfigureWebHostDefaults(
                                        webBuilder =>
                                        {
                                            webBuilder
                                                .UseContentRoot(Directory.GetCurrentDirectory())
                                                .UseKestrel()
                                                .UseStartup<Startup>();
                                        }
                                    )
                                    .Build();

                                aspNetCoreHost.StartAsync(cancellationTokenSource.Token)
                                    .Wait(cancellationTokenSource.Token);
                                runtime.Start();
                            }
                        );

                        service.WhenStopped(
                            runtime =>
                            {
                                runtime.Stop();

                                // Останавливаем веб-сервис.
                                var lifetime = aspNetCoreHost?.Services.GetService<IHostLifetime>() as IDisposable;
                                lifetime?.Dispose();
                            }
                        );
                    }
                );

                config.RunAsLocalService();
                config.StartAutomatically();

                config.EnableServiceRecovery(x => x.RestartService(delayInMinutes: 0));
            }
        );
    }
}