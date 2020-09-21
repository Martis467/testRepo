using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SampleProject.WebApi.Controllers
{
    using System.Linq;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            var weatherForecast = Database.GetWeatherInformation().FirstOrDefault();

            return weatherForecast;
        }

        [HttpGet("city")]
        public WeatherForecast GetForCity([FromRoute] string city)
        {
            var weatherInformation = Database.GetWeatherInformation();
            return GetForCity(weatherInformation, city);
        }

        private WeatherForecast GetForCity(IEnumerable<WeatherForecast> weatherInformation, string city)
        {
            foreach (var w in weatherInformation)
            {
                if (w.City.Equals(city))
                {
                    return w;
                }
            }
            return null;
        }
    }
}
