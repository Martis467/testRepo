using System;
using System.Collections.Generic;

namespace SampleProject.WebApi
{
    public static class Database
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static IEnumerable<WeatherForecast> GetWeatherInformation()
        {
            var rng = new Random();

            return new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    City = "Vilnius",
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                },

                new WeatherForecast
                {
                    City = "Kaunas",
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                },

                new WeatherForecast
                {
                    City = "Klaipeda",
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                },

                new WeatherForecast
                {
                    City = "Utena",
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                },

                new WeatherForecast
                {
                    City = "Taurage",
                    Date = DateTime.Now,
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                }
            };
        }
    }
}