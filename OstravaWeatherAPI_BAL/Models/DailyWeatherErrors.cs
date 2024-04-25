using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_BAL.Models
{
    public static class DailyWeatherErrors
    {
        public static readonly Error DailyWeatherNotFound = new("DailyWeather.NotFound", "DailyWeather not found");
    }
}
