using Xunit;

public class RequestTest
{
    [Fact]
    public void Test()
    {
        IRequestService requestService = new RequestService();

        var request1 = requestService.count();
        var request2 = requestService.count();
        
        Assert.Equal(1, request1);
        Assert.Equal(2, request2);
    }
}
