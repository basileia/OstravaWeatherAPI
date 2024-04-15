using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_DAL.Entities
{
    public class DailyWeather
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public float TemperatureMax { get; set; }
        public float TemperatureMin { get; set; }
        public float RainSum { get; set; }
    }
}
