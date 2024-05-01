using OstravaWeatherAPI_DAL.Entities;
namespace OstravaWeatherAPI_BAL.Models
{
    public class Weather
    {
        public int Id { get; set; }
        public Daily? Daily { get; set; }

        public DailyWeather ToDailyWeather()
        {
            DailyWeather dailyWeather = new DailyWeather
            {
                Id = Id
            };

            fillDailyWeather(Daily, dailyWeather);

            if (stringToDateOnly(Daily.Time[0]).Error == null)
            {
                dailyWeather.Date = stringToDateOnly(Daily.Time[0]).Value;
            }

            return dailyWeather;
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

        private void fillIfAvailable(List<float> data, Action<float> fillAction)
        {
            if (data != null && data.Count > 0)
            {
                fillAction(data[0]);
            }
        }

        private void fillDailyWeather(Daily dailyData, DailyWeather dailyWeather)
        {
            fillIfAvailable(dailyData.Temperature_2m_max, value => dailyWeather.TemperatureMax = value);
            fillIfAvailable(dailyData.Temperature_2m_min, value => dailyWeather.TemperatureMin = value);
            fillIfAvailable(dailyData.Rain_sum, value => dailyWeather.RainSum = value);
        }
    }
}
