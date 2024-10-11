using Microsoft.AspNetCore.Mvc;
using Dadata;
using Dadata.Model;

namespace Ddtatest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DadataTestController : ControllerBase
    {

        [ProducesResponseType(typeof(Address), 200)]
        [ApiVersion("1.0")]
        [HttpGet("")]
        public async Task<Address> GetData(string? address)
        {
            var token = "83590ed4ae489db7e127b3549898636c3dadcf3d";
            var secret = "a75a7f2f82ea849fa9980a3a78ce183b5e3157a8";
            var api = new CleanClientAsync(token, secret);
            var result = await api.Clean<Address>(address);
            return result;
        }
    }
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
