namespace OstravaWeatherAPI_BAL.Models
{
    public static class DailyWeatherErrors
    {
        public static readonly Error DailyWeatherNotFound = new("DailyWeather.NotFound", "DailyWeather not found");
    }
}
