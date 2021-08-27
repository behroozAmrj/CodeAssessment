using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WingTipsToys.WebApp.Mapping
{
      public class Human
      {
            public string HumanName { get; set; } = "behrooz";
      }

      public class Person : Human
      {
            public string PersonFamily { get; set; } = "No Man";
      }
}
