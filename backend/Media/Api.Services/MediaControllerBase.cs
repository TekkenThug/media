using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

public class MediaControllerBase<TService> : ControllerBase
{
    protected readonly TService Service;

    public MediaControllerBase(TService service)
    {
        Service = service;
    }
}