using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.WebApp.Controllers;

namespace WingTipsToys.WebApp.ActionFilters
{
      /// <summary>
      /// this class is used in order to preceding some code must be audit or authorized services actions
      /// </summary>
      public class AuthorizeFilterAttribute : ActionFilterAttribute
      {
            public override void OnActionExecuted(ActionExecutedContext context)
            {
                  var controller = context.Controller as MasterApiController;


                  base.OnActionExecuted(context);
            }

            public override void OnActionExecuting(ActionExecutingContext context)
            {
                  //var filters = context.Filters;
                  //// And filter it like this: 
                  //var filtered = filters.OfType<MyFilterType>()
                  //                        .Any();

                  //(filterContext.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes<MyAttribute>().FirstOrDefault();
                  base.OnActionExecuting(context);
            }
      }
}
