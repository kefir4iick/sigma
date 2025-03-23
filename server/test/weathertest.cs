using Xunit;

public class WeatherTest
{
    [Fact]
    public void Test()
    {
        var weatherService = new WeatherService();
        var values = new[] { "rain", "cold", "sunny" };
        
        var result = weatherService.weather();
        
        Assert.Contains(result, values);
    }
}
