using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WingTipsToys.WebApp.ActionFilters;

namespace WingTipsToys.WebApp.Controllers
{
      [Route("api/[controller]/[action]")]
      [ApiResultFilterAttribute]
      [AuthorizeFilter]
      [ApiController]
      public class MasterApiController : ControllerBase

      {
      }
}
