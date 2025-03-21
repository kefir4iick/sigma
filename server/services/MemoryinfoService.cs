public interface IMemoryinfoService
{
    long freespace();
}

public class MemoryinfoService : IMemoryinfoService
{
    private static DateTime start_time = DateTime.UtcNow;

    public long freespace()
    {
        var drive = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory));
        return (drive.AvailableFreeSpace / 1024) / 1024;
    }
}
