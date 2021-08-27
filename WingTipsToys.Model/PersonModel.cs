using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WingTipsToys.Model
{
      [Table("Person")]
      public class PersonModel : BaseEntity
      {
            [Key]
            public Guid Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Activity { get; set; }
            public string Comment { get; set; }
      }
}
