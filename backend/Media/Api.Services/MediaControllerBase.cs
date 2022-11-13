using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

public class MediaControllerBase<TService> : ControllerBase where TService : MediaServiceBase
{
    protected readonly TService Service;

    public MediaControllerBase(TService service)
    {
        Service = service;
    }
}