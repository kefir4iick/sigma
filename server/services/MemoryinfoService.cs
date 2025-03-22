using System.Diagnostics;

public interface IMemoryinfoService
{
    long memoryinfo();
}

public class MemoryinfoService : IMemoryinfoService
{
    private static DateTime start_time = DateTime.UtcNow;

    public long memoryinfo()
    {
        var proc = Process.GetCurrentProcess();
        return (proc.WorkingSet64 / 1024) / 1024;
    }
}
