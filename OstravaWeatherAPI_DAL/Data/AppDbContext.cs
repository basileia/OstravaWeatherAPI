using Microsoft.EntityFrameworkCore;
using OstravaWeatherAPI_DAL.Entities;

namespace OstravaWeatherAPI_DAL.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<DailyWeather> DailyWeather { get; set; }        
    }
}
