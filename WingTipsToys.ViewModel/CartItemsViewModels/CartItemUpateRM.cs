using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WingTipsToys.ViewModel.CartItemsViewModels
{
      public class CartItemUpateRM
      {

            [Required(ErrorMessage = "the quantity is necessary")]
            public int Quantity { get; set; }
            [Required(ErrorMessage = "relevate product is not provide!")]
            public int ProductId { get; set; }
            [Required(ErrorMessage = "ItemId is not definded!")]
            public Guid ItemId { get; set; }
            [Required(ErrorMessage = "ItemId is not definded!")]
            public Guid CartId { get; set; }
      }
}
