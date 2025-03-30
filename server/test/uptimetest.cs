using Xunit;

[Collection("NonParallelTests")]
public class UptimeTest
{
    [Fact]
    public void Test1()
    {
        IUptimeService uptimeService = new UptimeService();

        var inituptime = uptimeService.getuptime();
        
        Thread.Sleep(300);
        
        var sleepuptime = uptimeService.getuptime();
        var dif = sleepuptime - inituptime;
        
        Assert.True(inituptime >= TimeSpan.Zero);
        Assert.True(inituptime < TimeSpan.FromMilliseconds(60));
        Assert.True(dif >= TimeSpan.FromMilliseconds(290));
        Assert.True(dif <= TimeSpan.FromMilliseconds(350));
    }

    [Fact]
    public void Test2()
    {
        IUptimeService uptimeService = new UptimeService();
        var last = uptimeService.getuptime();

        for (int i = 0; i < 25; i++)
        {
            var now = uptimeService.getuptime();
            
            Assert.True(now > last);
            
            last = now;
            
            Thread.Sleep(100);
        }
        
    }
}
