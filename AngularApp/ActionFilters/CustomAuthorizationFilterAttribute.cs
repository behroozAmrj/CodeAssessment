using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.DataAccess;
using WingTipsToys.Model;

namespace WingTipsToys.WebApp.ActionFilters
{
      public class CustomAuthorizationFilterAttribute : Attribute, IAuthorizationFilter
      {
            private readonly ApplicationDBContext _appContext;

            public CustomAuthorizationFilterAttribute()
            {
            }
            public void OnAuthorization(AuthorizationFilterContext context)
            {
                  //var dbContext = context.HttpContext

                  //                        .RequestServices.GetRequiredService<ApplicationDBContext>();
                  //if (dbContext == null)
                  //{
                  //      context.Result = new UnauthorizedObjectResult(new { name = "Null App Context", stat = 10 });
                  //      return;
                  //}


                  //var list = context.HttpContext
                  //                   .Request
                  //                   .Headers
                  //                   .ToList();

                  //int count = list.Count;

                  //if (count >= 8)
                  //{
                  //      var unAuth = new UnauthorizedResult();
                  //      context.Result = new UnauthorizedObjectResult(new { name="unAuth" , stat = 10});
                  //      return;
                  //}
            }
      }
}
