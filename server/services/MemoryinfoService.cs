using System.Diagnostics;

public interface IMemoryinfoService
{
    long memoryinfo();
}

public class MemoryinfoService : IMemoryinfoService
{
    public long memoryinfo()
    {
        var proc = Process.GetCurrentProcess();
        return (proc.WorkingSet64 / 1024) / 1024;
    }
}
