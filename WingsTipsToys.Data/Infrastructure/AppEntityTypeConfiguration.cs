using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WingTipsToys.Model;

namespace WingTipsToys.Data.Infrastructure
{
      public class AppEntityTypeConfiguration<TEntity> : IDataMapping, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
      {
            public void ApplyConfiguration(ModelBuilder modelBuilder)
            {
                  modelBuilder.ApplyConfiguration(this);
            }

            public virtual void Configure(EntityTypeBuilder<TEntity> builder)
            {
                  DoConfiguration(builder);
            }

            protected  void DoConfiguration(EntityTypeBuilder<TEntity> builder)
            {
            }
      }
}
