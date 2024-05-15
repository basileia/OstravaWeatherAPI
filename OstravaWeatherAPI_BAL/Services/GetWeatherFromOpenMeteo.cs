using Coravel.Invocable;
using OstravaWeatherAPI_BAL.Extensions;
using OstravaWeatherAPI_DAL.Contracts;

namespace OstravaWeatherAPI_BAL.Services
{
    public class GetWeatherFromOpenMeteo : IInvocable
    {
        private readonly IRepositoryDailyWeather _repositoryDailyWeather;
        private readonly DataDownloader _dataDownloader;

        public GetWeatherFromOpenMeteo(IRepositoryDailyWeather repositoryDailyWeather, DataDownloader dataDownloader)
        {
            _repositoryDailyWeather = repositoryDailyWeather;
            _dataDownloader = dataDownloader;
        }
        public async Task Invoke()
        {
            var dailyWeather = await _dataDownloader.DownloadAndParseData(); 
            
            if (dailyWeather != null)
            {
                if (!dailyWeatherExists(dailyWeather.Date))
                {
                    _repositoryDailyWeather.Add(dailyWeather);
                }
            }                       
        }

        private bool dailyWeatherExists(DateOnly date)
        {                    
            return _repositoryDailyWeather.ExistsByDate(date);
        }
    }
}
