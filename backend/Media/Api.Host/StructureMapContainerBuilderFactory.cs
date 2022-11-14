using StructureMap;

namespace Api.Host;

public class StructureMapContainerBuilderFactory : IServiceProviderFactory<IContainer>
{
    private readonly IContainer _container;
    private IServiceCollection? _services;

    public StructureMapContainerBuilderFactory(IContainer container)
    {
        _container = container;
    }
        
    /// <inheritdoc />
    public IContainer CreateBuilder(IServiceCollection services)
    {
        _services = services;
                
        return _container;
    }

    /// <inheritdoc />
    public IServiceProvider CreateServiceProvider(IContainer builder)
    {
        builder.Configure(
            config =>
            {
                config.Populate(_services);
            }
        );

        return builder.GetInstance<IServiceProvider>();
    }
}