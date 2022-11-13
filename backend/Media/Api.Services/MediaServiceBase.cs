using Api.Db;

namespace Api.Services;

public class MediaServiceBase
{
    protected readonly ApplicationContext Context;
    
    public MediaServiceBase(ApplicationContext context)
    {
        Context = context;
    }
}