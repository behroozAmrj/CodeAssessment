using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.WebApp.Mapping;

namespace WingTipsToys.WebApp.ActionFilters
{
      

      public class GreetingTypeFilterWapper : TypeFilterAttribute
      {
            public Type MyName { get; private set; }
            public GreetingTypeFilterWapper(Type type )
                  : base(typeof(GreetingTypeFilter))
            {
                 // type ?? throw new Argument
                  MyName = type;
            }

            private class GreetingTypeFilter : IActionFilter
            {
                  public void OnActionExecuted(ActionExecutedContext context)
                  {
                         throw new NotImplementedException();
                  }

                  public void OnActionExecuting(ActionExecutingContext context)
                  {
                         throw new NotImplementedException();
                  }
            }
      }


      public class Auther :Attribute
      {
            public Type  Value { get; private set; }
            public Auther(Type type)
            {
                  this.Value = type;
            }
      }
}
