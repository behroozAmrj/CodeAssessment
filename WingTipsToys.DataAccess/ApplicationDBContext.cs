using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WingTipsToys.Data;
using WingTipsToys.Data.Infrastructure;

namespace WingTipsToys.DataAccess
{
      public class ApplicationDBContext : DbContext
      {
            public ApplicationDBContext(DbContextOptions dbOptions)
                                          :base(dbOptions)
            {

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {//IEntityTypeConfiguration

                  var assemList = AppDomain.CurrentDomain.
                                                GetAssemblies()
                                                .Where(x => x.FullName.Contains("WingTipsToys.Data"))
                                                .ToList();
                                                
                                                
                         
                                                
                  foreach (var ass in assemList)
                  {
                        var configList = ass.GetTypes()
                                                      .Where(type => (type.BaseType?.IsGenericType ?? false)
                                                              && (type.BaseType.GetGenericTypeDefinition() == typeof(AppEntityTypeConfiguration<>)))
                                                      .ToList();

                        //   modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
                        base.OnModelCreating(modelBuilder);
                        foreach (var typeConfiguration in configList)
                        {
                              var configuration = (IDataMapping)Activator.CreateInstance(typeConfiguration);
                              configuration.ApplyConfiguration(modelBuilder);
                        }

                  }
                  ////var config = Activator.CreateInstance(item) ;


                  //modelBuilder.ApplyConfiguration(new ProductMapper());
                 // modelBuilder.ApplyConfiguration(new CategoryData());
                  //modelBuilder.ApplyConfiguration(new CartItemData());

                  // modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            }
      }
}
