using Coravel.Invocable;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Entities;

namespace OstravaWeatherAPI_BAL.Services
{
    public class GetWeatherFromOpenMeteo : IInvocable
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IRepositoryDailyWeather _repositoryDailyWeather;

        public GetWeatherFromOpenMeteo(HttpClient httpClient, IConfiguration config, IRepositoryDailyWeather repositoryDailyWeather)
        {
            _httpClient = httpClient;
            _config = config;
            _repositoryDailyWeather = repositoryDailyWeather;
        }
        public async Task Invoke()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_config["BaseUrl"] + _config["UrlParameters"]);
            response.EnsureSuccessStatusCode();

            string responseJsonString = await response.Content.ReadAsStringAsync();

            Weather weather = JsonConvert.DeserializeObject<Weather>(responseJsonString);
            
            DailyWeather dailyWeather = weather.ToDailyWeather();
            
            if (!dailyWeatherExists(dailyWeather.Date))
            {
                _repositoryDailyWeather.Add(dailyWeather);
            }        
        }

        private bool dailyWeatherExists(DateOnly date)
        {                    
            return _repositoryDailyWeather.ExistsByDate(date);
        }
    }
}
