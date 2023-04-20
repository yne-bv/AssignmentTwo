using ASP.NETCoreWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NETCoreWebApplication.DAL;

public class WeatherContext : DbContext
{
    public DbSet<Weather> Weather { get; set; }

    public WeatherContext()
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("weatherData");
        // optionsBuilder.UseSqlServer(
        //     @"Server=(localdb)\mssqllocaldb;Database=Weather;Trusted_Connection=True");
    }
}