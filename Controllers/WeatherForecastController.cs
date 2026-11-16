using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MySwaggerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        /// <summary>
        /// Gets a list of weather forecasts.
        /// </summary>
        /// <returns>A list of weather forecasts</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), 200)]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    /// <summary>
    /// Weather forecast for one day.
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>Forecast date.</summary>
        public DateTime Date { get; set; }

        /// <summary>Temperature in Celsius.</summary>
        public int TemperatureC { get; set; }

        /// <summary>Short text description.</summary>
        public string Summary { get; set; } = string.Empty;

        /// <summary>Temperature in Fahrenheit.</summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
