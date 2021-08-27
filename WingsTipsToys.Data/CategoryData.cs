using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WingTipsToys.Model;

namespace WingTipsToys.Data
{
      public class CategoryData : IEntityTypeConfiguration<CategoryModel>
      {
            public void Configure(EntityTypeBuilder<CategoryModel> builder)
            {
                  builder.HasKey(x => x.CategoryID);
                  builder.Property(x => x.CategoryName);
                  builder.Property(x => x.Description);
            }
      }
}
