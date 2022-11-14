using Microsoft.AspNetCore.Mvc;

namespace Api.Services;

[Route("api/[controller]")]
[ApiController]
public class MediaControllerBase<TService> : ControllerBase
{
    protected readonly TService Service;

    public MediaControllerBase(TService service)
    {
        Service = service;
    }
}