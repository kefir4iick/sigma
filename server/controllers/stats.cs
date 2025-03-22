using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;

[ApiController]
[Route("[controller]")]
public class Stats : ControllerBase
{
    private readonly IFreespaceService _freespaceService;
    private readonly IMemoryinfoService _memoryinfoService;
    private readonly IRequestService _requestService;
    private readonly IUptimeService _uptimeService;
    
    public Stats(IFreespaceService freespaceService,
        IMemoryinfoService memoryinfoService,
        IRequestService requestService,
        IUptimeService uptimeService)
    {
        _freespaceService = freespaceService;
        _memoryinfoService = memoryinfoService;
        _requestService = requestService;
        _uptimeService = uptimeService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var free_space = _freespaceService.freespace();
        var mem = _memoryinfoService.memoryinfo();
        var request_count = _requestService.count();
        var uptime = _uptimeService.getuptime();
    

        return Ok(new
        {
            uptime = uptime,
            request_count = request_count,
            free_space = free_space,
            mem = mem
        });
    }
}
