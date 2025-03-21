public interface IUptimeService
{
    TimeSpan getuptime();
}

public class UptimeService : IUptimeService
{
    private static DateTime start_time = DateTime.UtcNow;

    public TimeSpan getuptime()
    {
        return DateTime.UtcNow - start_time;
    }
}
