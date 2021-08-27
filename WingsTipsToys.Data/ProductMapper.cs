using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WingTipsToys.Model;

namespace WingTipsToys.Data
{
      public class ProductMapper : IEntityTypeConfiguration<ProductModel>
      {
            public void Configure(EntityTypeBuilder<ProductModel> builder)
            {
                  builder.HasKey(x => x.ProductID);
                  builder.Property(x => x.ProductName);
            }
      }
}
