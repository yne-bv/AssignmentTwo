namespace ASP.NETCoreWebApplication.Models;

public class Weather
{
    public int WeatherId { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public double TemperatureC { get; set; }
    public int Cloud { get; set; }
    public double WindKph { get; set; }
    public string Date { get; set; }
}