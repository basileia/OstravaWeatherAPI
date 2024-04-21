using AutoMapper;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_DAL.Contracts;
using OstravaWeatherAPI_DAL.Entities;
using System;
namespace OstravaWeatherAPI_BAL.Services
{
    public class ServiceDailyWeather
    {
        private readonly IRepositoryDailyWeather _repositoryDailyWeather;
        private readonly IMapper _mapper;

        public ServiceDailyWeather(IRepositoryDailyWeather repositoryDailyWeather, IMapper mapper)
        {
            _repositoryDailyWeather = repositoryDailyWeather;
            _mapper = mapper;
        }

        public List<DailyWeatherModel> GetAllDailyWeather()
        {
            List<DailyWeather> dailyWeather = _repositoryDailyWeather.GetAll();
            List<DailyWeatherModel> dailyWeatherModel = _mapper.Map<List<DailyWeather>, List<DailyWeatherModel>>(dailyWeather);

            return dailyWeatherModel;
        }


    }
}
