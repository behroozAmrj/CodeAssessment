using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.ViewModel;

namespace WingTipsToys.WebApp.ActionFilters
{
      public class ApiResultFilterAttribute : ResultFilterAttribute
      {
            public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
            {
                  var resultFormat = context.Result as ObjectResult;
                  string controllerName = context.Controller.ToString();

                  resultFormat.Value = new ResponseContainerModel() { Data = resultFormat.Value, ResponseTime = DateTime.Now };
                  return base.OnResultExecutionAsync(context, next);
            }

      }
}
