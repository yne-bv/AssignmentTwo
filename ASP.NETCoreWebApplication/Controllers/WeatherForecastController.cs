using System.Globalization;
using ASP.NETCoreWebApplication.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETCoreWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherManagement _weatherManagement;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(
        IWeatherManagement weatherManagement,
        ILogger<WeatherForecastController> logger)
    {
        _weatherManagement = weatherManagement;
        _logger = logger;
    }

    [HttpGet]
    public async Task<List<Weather>> Get()
    {
        return await _weatherManagement.Get();
    }
}