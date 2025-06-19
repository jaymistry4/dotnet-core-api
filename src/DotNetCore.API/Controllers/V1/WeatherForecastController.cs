using DotNetCore.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers.V1
{
    [ApiVersion("1.0")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Route("api/v{version:apiversion}/[controller]")]
    [ApiController]
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

        /// <summary>
        /// Authorization token not required.
        /// </summary>
        /// <returns></returns>
        /// <response code="200">Returns the weatherforecast list</response>
        /// <response code="500">If there was an internal server error</response>
        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
