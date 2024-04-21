using AutoMapper;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_DAL.Entities;

namespace OstravaWeatherAPI_BAL.Extensions
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {
            CreateMap<DailyWeather, DailyWeatherModel>().ReverseMap();
        }
    }
}
