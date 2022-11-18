using Api.Data;
using Api.Data.User;
using Api.Host.Configuration;
using Api.Services.User;
using StructureMap;

namespace Api.Host;

public class MediaBootstrapper
{
    public static MediaBootstrapper Instance { get; } = new();

    public IContainer Container { get; private set; }

    public void Bootstrap()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: false)
            .Build();

        var mediaConfiguration = config.GetSection(key: "Media").Get<MediaConfiguration>();

        this.Container = new Container(
            x =>
            {
                x.For<MediaConfiguration>().Use(mediaConfiguration);
            }
        );
    }
}