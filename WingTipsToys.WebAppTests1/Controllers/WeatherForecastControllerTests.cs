using Xunit;
using AngularApp.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using AutoMapper;
using WingTipsToys.WebApp.Mapping;

namespace AngularApp.Controllers.Tests
{
      public class WeatherForecastControllerTests
      {
            [Fact()]
            public void WeatherForecastControllerTest()
            {
                  var myProfile = new MappingProfile();
                  var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                  var mapper = new Mapper(configuration);
                  
                  
                  var mock = new Mock<ILogger<WeatherForecastController>>();
                  ILogger<WeatherForecastController> logger = mock.Object;

                  //or use this short equivalent 
                  logger = Mock.Of<ILogger<WeatherForecastController>>();

                  var forCast = new WeatherForecastController(logger , mapper);
                  var result = forCast.Gets();

                  Assert.IsType<List<WeatherForecast>>(result);
            }

            
      }
}