using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Data;
using OstravaWeatherAPI_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_DAL.Repository
{
    public class RepositoryDailyWeather : RepositoryBase<DailyWeather>, IRepositoryDailyWeather
    {
        public RepositoryDailyWeather(AppDbContext context) : base(context) { }

        public bool ExistsByDate(DateOnly date)
        {
            return EntityExists(e => e.Date == date);
        }
    }
}
