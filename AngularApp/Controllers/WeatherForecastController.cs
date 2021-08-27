using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WingTipsToys.WebApp.ActionFilters;
using WingTipsToys.WebApp.Controllers;

namespace AngularApp.Controllers
{
      public class Per
      {
            public int ID { get; set; }
            public string Name { get; set; }
      }


      
      public class WeatherForecastController : Controller//MasterApiController
      {
            private static readonly string[] Summaries = new[]
            {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

            private readonly ILogger<WeatherForecastController> _logger;
            private readonly IMapper _mapper;

            public WeatherForecastController(ILogger<WeatherForecastController> logger , IMapper mapper)
            {
                  _logger = logger;
                  this._mapper = mapper;
            }
            [CustomAuthorizationFilterAttribute]
            [HttpGet]
            public IEnumerable<WeatherForecast> Gets()
            {
                
                  var rng = new Random();
                  var res =  Enumerable.Range(1, 5).Select(index => new WeatherForecast { 
                  
                        
                              Date = DateTime.Now.AddDays(index),
                              TemperatureC = rng.Next(-20, 55),
                              Summary = Summaries[rng.Next(Summaries.Length)]
                       
                  })
                  .ToList();
                  return (res);
            }

            [HttpPost]
            public IEnumerable<WeatherForecast> Post([FromBody] Per person)
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
}
