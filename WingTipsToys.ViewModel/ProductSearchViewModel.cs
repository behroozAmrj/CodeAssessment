using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WingTipsToys.ViewModel
{
      public class ProductSearchViewModel
      {
            [Required(ErrorMessage = "No search value is provided!")]
            [MinLength(3, ErrorMessage = "Search value must be at least 3 carachters")]
            public string ProductName { get; set; }
      }
}
