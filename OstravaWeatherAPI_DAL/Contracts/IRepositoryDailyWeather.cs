using OstravaWeatherAPI_DAL.Entities;

namespace OstravaWeatherAPI_DAL.Contracts
{
    public interface IRepositoryDailyWeather : IRepositoryBase<DailyWeather>
    {
        bool ExistsByDate(DateOnly date);
        DailyWeather GetByDate(DateOnly date);
    }
}

