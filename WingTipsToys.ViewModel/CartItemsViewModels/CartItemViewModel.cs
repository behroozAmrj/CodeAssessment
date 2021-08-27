using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WingTipsToys.ViewModel
{
      public class CartItemViewModel
      {
            public string ItemId { get; set; }
            public string CartId { get; set; }

            public int Quantity { get; set; }
            public DateTime DateCreated { get; set; }

            public int ProductId { get; set; }
            public string ProductName { get; set; }
      }
}
