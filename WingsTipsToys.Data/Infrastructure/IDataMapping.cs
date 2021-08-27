using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WingTipsToys.Data.Infrastructure
{
      public interface IDataMapping
      {
            void ApplyConfiguration(ModelBuilder modelBuilder);
      }
}
