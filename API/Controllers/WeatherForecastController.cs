using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
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

        [HttpGet("{summary}")]
        public ActionResult<WeatherForecast> GetBySummary(string summary)
        {
            var wth = new WeatherForecast
            {
                Summary = summary
            };
            
            return Ok(wth);
        }

        [HttpPost("create")]
        public ActionResult<WeatherForecast> Post(WeatherForecast weatherForecast)
        {
            var wth = weatherForecast;
            return Ok(wth);
        }
        
        [HttpPut("update/{summary}")]
        public ActionResult<WeatherForecast> Put(string summary, WeatherForecast weatherForecast)
        {
            return Ok(weatherForecast);
        }
        
        [HttpDelete("delete/{summary}")]
        public ActionResult<string> Delete(string summary)
        {
            //Query de busca de dados com base summary
            
            //delete de dados 
            
            return Ok(summary);
        }
        
        
        //CRUD => Create / Read /Update / Delete  
    }
}