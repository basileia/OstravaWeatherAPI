using OstravaWeatherAPI_DAL.Entities;
namespace OstravaWeatherAPI_BAL.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public Daily? Daily { get; set; }
        
        public DailyWeather ToDailyWeather()
        {  
            DailyWeather dailyweather = new DailyWeather();
            dailyweather.Id = Id;
            dailyweather.TemperatureMax = Daily.Temperature_2m_max[0];
            dailyweather.TemperatureMin = Daily.Temperature_2m_min[0];
            dailyweather.RainSum = Daily.Rain_sum[0];
            
            if (stringToDateOnly(Daily.Time[0]).Error == null)
            {                
                dailyweather.Date = stringToDateOnly(Daily.Time[0]).Value;
            }

            return dailyweather;
        }

        private Result<DateOnly, Error> stringToDateOnly(string dateString)
        {
            DateOnly date;

            if (DateOnly.TryParseExact(dateString, "yyyy-MM-dd", out date))
            {
                return date;
            }
            return WeatherErrors.DateNotConverted;
        }
    }
}
