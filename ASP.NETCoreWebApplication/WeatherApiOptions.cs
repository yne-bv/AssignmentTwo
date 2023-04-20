namespace ASP.NETCoreWebApplication;

public class WeatherApiOptions
{
    public const string WeatherApi = "WeatherApi";

    public string Uri { get; set; } = String.Empty;
    public string ApiKey { get; set; } = String.Empty;
}