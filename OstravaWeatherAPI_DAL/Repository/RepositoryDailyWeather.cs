using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Data;
using OstravaWeatherAPI_DAL.Entities;

namespace OstravaWeatherAPI_DAL.Repository
{
    public class RepositoryDailyWeather : RepositoryBase<DailyWeather>, IRepositoryDailyWeather
    {
        public RepositoryDailyWeather(AppDbContext context) : base(context) { }

        public bool ExistsByDate(DateOnly date)
        {
            return EntityExists(e => e.Date == date);
        }

        public DailyWeather GetByDate(DateOnly date)
        {
            return GetByPredicate(e => e.Date == date);
        }
    }
}
