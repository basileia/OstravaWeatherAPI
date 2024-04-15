using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_BAL.Models
{
    public static class WeatherErrors
    {
        public static readonly Error DateNotConverted = new("Weather.NotConverted", "String to date conversion failed");
    }
}
