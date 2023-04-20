using System.Globalization;

namespace ASP.NETCoreWebApplication.Models;

public static class WeatherApiMapper
{
    public static Weather ToWeather(this WeatherApiData weatherApiData)
    {
        return new Weather
        {
            Country = weatherApiData.location.country,
            City = weatherApiData.location.name,
            Cloud = weatherApiData.current.cloud,
            TemperatureC = weatherApiData.current.temp_c,
            WindKph = weatherApiData.current.wind_kph,
            Date = DateTime.UtcNow.ToString("hh:mm")
        };
    }
}