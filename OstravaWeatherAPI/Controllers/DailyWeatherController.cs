using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_BAL.Services;

namespace OstravaWeatherAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DailyWeatherController : BaseController
    {
        private readonly ServiceDailyWeather _serviceDailyWeather;

        public DailyWeatherController(ServiceDailyWeather serviceDailyWeather)
        {
            _serviceDailyWeather = serviceDailyWeather;
        }

        [HttpGet]
        public ActionResult<List<DailyWeatherModel>> GetAllDailyWeather()
        {
            return _serviceDailyWeather.GetAllDailyWeather();
        }

        [HttpGet("{id}")]
        public ActionResult<DailyWeatherModel> GetDailyWeatherById(int id)
        {
            return GetResponse(_serviceDailyWeather.GetDailyWeatherById(id));
        }

        [HttpGet("{date}")]
        public ActionResult<DailyWeatherModel> GetDailyWeatherByDate(DateOnly date)
        {
            return GetResponse(_serviceDailyWeather.GetByDate(date));
        }




    }
}
