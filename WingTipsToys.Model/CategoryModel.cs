using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WingTipsToys.Model
{
      [Table("Categories")]
      public class CategoryModel : BaseEntity
      {
            [Key]
            public int CategoryID { get; set; }
            public string CategoryName { get; set; }
            public string Description { get; set; }
      }
}
