using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WingTipsToys.Model
{
      [Table("Products")]
      public class ProductModel : BaseEntity
      {
            [Key]
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public string Description { get; set; }
            public string ImagePath { get; set; }
            public double UnitPrice { get; set; }
            public int    CategoryID { get; set; }
      }
}
