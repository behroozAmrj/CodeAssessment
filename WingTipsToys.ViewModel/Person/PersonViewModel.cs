using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WingTipsToys.ViewModel.Person
{
      public class PersonViewModel
      {
            public Guid Id { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Activity { get; set; }
            [Required]
            public string Comment { get; set; }
      }
}
