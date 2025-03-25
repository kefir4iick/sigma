public interface IFreespaceService
{
    long freespace();
}

public class FreespaceService : IFreespaceService
{
    public long freespace()
    {
        var drive = new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory));
        return (drive.AvailableFreeSpace / 1024) / 1024;
    }
}
