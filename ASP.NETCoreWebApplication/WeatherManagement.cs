using System.Text.Json;
using ASP.NETCoreWebApplication.DAL;
using ASP.NETCoreWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ASP.NETCoreWebApplication;

public class WeatherManagement : IWeatherManagement
{
    private readonly WeatherApiOptions _weatherApiOptions;
    private static readonly HttpClient _httpClient = new HttpClient();

    public WeatherManagement(
        IOptions<WeatherApiOptions> weatherApiOptions)
    {
        _weatherApiOptions = weatherApiOptions.Value;
    }

    public async Task<List<Weather>> Get()
    {
        await using var db = new WeatherContext();
        var weather = await db.Weather
            .ToListAsync();

        var listWithMaxTemp = weather.Max(x => x.TemperatureC);
        
        return await db.Weather
            .ToListAsync();
    }
    
    public async Task UpdateDatabase()
    {
        var osloWeather = await FetchWeatherDataFromCity("oslo");
        var stavangerWeather = await FetchWeatherDataFromCity("stavanger");
        var bergenWeather = await FetchWeatherDataFromCity("bergen");
        var lillestromWeather = await FetchWeatherDataFromCity("lillestrom");
        var cayonWeather = await FetchWeatherDataFromCity("cayon");
        var charlestownWeather = await FetchWeatherDataFromCity("charlestown");
        var basseterreWeather = await FetchWeatherDataFromCity("basseterre");
        var caracasWeather = await FetchWeatherDataFromCity("caracas");
        var kathmanduWeather = await FetchWeatherDataFromCity("kathmandu");
        var luandaWeather = await FetchWeatherDataFromCity("luanda");

        List<Weather> weatherData = new List<Weather>
        {
            osloWeather.ToWeather(),
            stavangerWeather.ToWeather(),
            bergenWeather.ToWeather(),
            lillestromWeather.ToWeather(),
            cayonWeather.ToWeather(),
            charlestownWeather.ToWeather(),
            basseterreWeather.ToWeather(),
            caracasWeather.ToWeather(),
            kathmanduWeather.ToWeather(),
            luandaWeather.ToWeather()
        };

        await using var db = new WeatherContext();
        await db.AddRangeAsync(weatherData);
        await db.SaveChangesAsync();
        Console.WriteLine($"Update Database: at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    private async Task<WeatherApiData?> FetchWeatherDataFromCity(
        string city)
    {
        string weatherEndpoint = $"{_weatherApiOptions.Uri}/v1/current.json?key={_weatherApiOptions.ApiKey}";
        var response = await _httpClient.GetAsync($"{weatherEndpoint}&q={city}");
        var responseAsString = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<WeatherApiData>(responseAsString);
    }
}

public interface IWeatherManagement
{
    Task<List<Weather>> Get();
    Task UpdateDatabase();
}