using Xunit;

public class FreeSpaceTest
{
    [Fact]
    public void Test()
    {
        IFreespaceService freespaceService = new FreespaceService();
        var last = freespaceService.freespace();

        for(int i = 0; i < 25; i++)
        {
            var now = freespaceService.freespace();
            
            Assert.True(now <= last);

            last = now;
        }
    }
}
