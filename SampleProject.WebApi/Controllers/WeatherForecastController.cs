using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SampleProject.WebApi.Controllers
{
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
            var rng = new Random();

            return new WeatherForecast
            {
                City = "Vilnius",
                Date = DateTime.Now,
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            };
        }

        // My to-be code changes are down here:

        // This is commented out because I'll adjust the get function
        //[HttpGet]
        //public WeatherForecast Get()
        //{
        //    var weatherInformation = Database.GetWeatherInformation();

        //    return GetForCity(weatherInformation, "Vilnius");

        //}

        [HttpGet("city")]
        public WeatherForecast GetForCity([FromRoute] string city)
        {




            var weatherInformation = Database.GetWeatherInformation();

            return GetForCity(weatherInformation, city);
        }

        // Function that could be replaced with a simple where condition
        private WeatherForecast GetForCity(IEnumerable<WeatherForecast> weatherInformation, string city)
        {
            foreach(var w in weatherInformation)
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
