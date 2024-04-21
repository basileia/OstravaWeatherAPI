namespace OstravaWeatherAPI_BAL.Models
{
    public class DailyWeatherModel
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public float TemperatureMax { get; set; }
        public float TemperatureMin { get; set; }
        public float RainSum { get; set; }
    }
}
