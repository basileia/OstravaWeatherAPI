namespace OstravaWeatherAPI_BAL.Models
{
    public class Daily
    {
        public List<string> Time { get; set; }
        public List<float> Temperature_2m_max { get; set; }
        public List<float> Temperature_2m_min { get; set; }
        public List<float> Rain_sum { get; set; }
    }
}
