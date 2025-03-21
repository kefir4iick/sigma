public interface IWeatherService
{
    string weather();
}

public class WeatherService : IWeatherService
{
    private static readonly string[] List = new[]
    {
        "rain", "cold", "sunny"
    };

    public string weather()
    {
        var random_value = new Random();
        return List[random_value.Next(List.Length)];
    }
}
