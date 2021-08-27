using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WingTipsToys.Model;

namespace WingTipsToys.Data
{
      public class CartItemData : IEntityTypeConfiguration<CartItemModel>
      {
            public void Configure(EntityTypeBuilder<CartItemModel> builder)
            {
                  builder.HasKey(x => x.CartId);
                  builder.Property(x => x.ItemId);
                  builder.Property(x => x.DateCreated);
                  builder.Property(x => x.Quantity);
                  builder.Property(x => x.ProductId);

            }
      }
}
