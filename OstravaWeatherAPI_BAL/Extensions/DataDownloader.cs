using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Entities;
using System.Net;

namespace OstravaWeatherAPI_BAL.Extensions
{
    public class DataDownloader
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IRepositoryDailyWeather _repositoryDailyWeather;

        public DataDownloader(HttpClient httpClient, IConfiguration config, IRepositoryDailyWeather repositoryDailyWeather)
        {
            _httpClient = httpClient;
            _config = config;
            _repositoryDailyWeather = repositoryDailyWeather;
        }

        private async Task<HttpResponseMessage> DownloadDataAsync()
        {
            return await _httpClient.GetAsync(_config["BaseUrl"] + _config["UrlParameters"]);
        }

        public async Task<DailyWeather?> DownloadAndParseData()
        {
            var response = await DownloadDataAsync();
            
            if (response.IsSuccessStatusCode)
            {
                string responseJsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Weather>(responseJsonString).ToDailyWeather();
                
            }
            return null;
        }

    }
}
