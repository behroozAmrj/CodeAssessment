using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WingTipsToys.Data.Infrastructure;
using WingTipsToys.Model;

namespace WingTipsToys.Data
{
      public class PersonData : AppEntityTypeConfiguration<PersonModel>
      {
            public override void Configure(EntityTypeBuilder<PersonModel> builder)
            {
                  builder.HasKey(p => p.Id);
                  builder.Property(p => p.FirstName);
                  builder.Property(p => p.LastName);
                  builder.Property(p => p.Email);
                  builder.Property(p => p.Comment);
                  builder.Property(p => p.Email);

            }

      }
}
