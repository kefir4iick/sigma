using Xunit;

public class RequestTest
{
    [Fact]
    public void Test()
    {
        var requestService = new RequestService();

        var request_1 = requestService.count();
        var request_2 = requestService.count();
        
        Assert.Equal(1, request_1);
        Assert.Equal(2, request_2);
    }
}
