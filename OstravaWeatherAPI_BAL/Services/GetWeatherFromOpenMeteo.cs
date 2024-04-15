﻿using Coravel.Invocable;
using Newtonsoft.Json;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OstravaWeatherAPI_BAL.Services
{
    public class GetWeatherFromOpenMeteo : IInvocable
    {
        private readonly HttpClient _httpClient;

        public GetWeatherFromOpenMeteo(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Invoke()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://api.open-meteo.com/v1/forecast?latitude=49.8347&longitude=18.282&daily=temperature_2m_max,temperature_2m_min,rain_sum&timezone=Europe%2FBerlin&forecast_days=1&models=best_match");
            response.EnsureSuccessStatusCode();

            string responseJsonString = await response.Content.ReadAsStringAsync();

            Weather weather = JsonConvert.DeserializeObject<Weather>(responseJsonString);
            DailyWeather dailyWeather = weather.ToDailyWeather();
            
        }

    }
}
