using System;

[ApiController]
[Route("[controller]")]
public class Weather : ControllerBase
{
    private static readonly string[] List = new[]
    {
        "rain", "cold", "sunny"
    };

    [HttpGet]
    public IActionResult Get()
    {
        var random_value = new Random();
        return Ok(new
        {
            weather = List[random_value.Next(List.Length)]
        });
    }
}
