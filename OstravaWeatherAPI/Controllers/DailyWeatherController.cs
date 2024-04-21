using Microsoft.AspNetCore.Mvc;
using OstravaWeatherAPI_BAL.Models;
using OstravaWeatherAPI_BAL.Services;

namespace OstravaWeatherAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DailyWeatherController : ControllerBase
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
    }
}
