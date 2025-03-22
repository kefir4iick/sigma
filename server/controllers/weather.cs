using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("[controller]")]
public class Weather : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public Weather(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var weather = _weatherService.weather();
        return Ok(new
        {
            weather
        });
    }
}
