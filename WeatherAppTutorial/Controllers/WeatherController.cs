using WeatherAppTutorial.Services;

namespace WeatherAppTutorial.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class WeatherController : ControllerBase
{
    private readonly WeatherService _weatherService;

    public WeatherController(WeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(double latitude, double longitude)
    {
        try
        {
            var weatherData = await _weatherService.GetWeatherDataAsync(latitude, longitude);
            return Ok(weatherData);
        }
        catch (Exception ex)
        {
            // Handle exceptions (e.g., API call failures)
            return StatusCode(500, ex.Message);
        }
    }
}
