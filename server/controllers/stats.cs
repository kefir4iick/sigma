using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Diagnostics;

[ApiController]
[Route("[controller]")]
public class Stats : ControllerBase
{
    private static int counter = 0;
    private static DateTime start_time = DateTime.UtcNow;

    [HttpGet]
    public IActionResult Get()
    {
        counter = counter + 1;
        var drive = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory));
        var proc = Process.GetCurrentProcess();
        
        return Ok(new
        {
            uptime = DateTime.UtcNow - start_time,
            request_count = counter,
            free_space = (drive.AvailableFreeSpace / 1024) / 1024,
            mem = (proc.WorkingSet64 / 1024) / 1024
        });
    }
}
