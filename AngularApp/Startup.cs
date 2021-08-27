using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WingTipsToys.BusinessContract;
using WingTipsToys.BusinessService;
using WingTipsToys.BusinessService.PersonBusiness;
using WingTipsToys.DataAccess;
using WingTipsToys.DataAccessContract;
using WingTipsToys.WebApp.ActionFilters;
using WingTipsToys.WebApp.Mapping;

namespace AngularApp
{
      public class Startup
      {
            public Startup(IConfiguration configuration)
            {
                  Configuration = configuration;
            }

            public IConfiguration Configuration { get; }

            // This method gets called by the runtime. Use this method to add services to the container.
            public void ConfigureServices(IServiceCollection services)
            {
                  services.AddAutoMapper(typeof(Startup));
                  services.AddControllersWithViews();
                  services.AddMvc((opt) =>
                  {
                        opt.Filters.Add(new ApiExceptionFilter());
                        opt.Filters.Add(typeof(CustomAuthorizationFilterAttribute));
                  });

                  services.AddControllers((opt) =>
                  {
                        opt.Filters.Add(new ApiExceptionFilter());

                  });

                  services.AddCors();
                  services.AddScoped<IProductBusinessContract, ProductBusinessService>();
                  services.AddScoped<ICategoryBusinessContract, CategoryBusinessService>();
                  services.AddScoped<ICartItemBusinessContract, CartItemBusinessService>();
                  services.AddScoped<IPersonBusinessContract, PersonBusinessService>();

                  //var myProfile = new MappingProfile();
                  //var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
                  //var mapper = new Mapper(configuration);
                  //services.AddScoped<IMapper , >();
                  string connectionString = Configuration.GetConnectionString("dbs");
                  services.AddDbContext<ApplicationDBContext>(dbOption => dbOption.UseSqlServer(connectionString));
                  services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                  // In production, the Angular files will be served from this directory
                  services.AddSpaStaticFiles(configuration =>
                  {
                        configuration.RootPath = "ClientApp/App/dist";
                  });
            }

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
                  if (env.IsDevelopment())
                  {
                        app.UseDeveloperExceptionPage();
                  }
                  else
                  {
                        app.UseExceptionHandler("/Error");
                        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                        app.UseHsts();
                  }

                  app.UseCors((opt) =>
                  {
                        opt.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                  });
                  app.UseHttpsRedirection();
                  app.UseStaticFiles();
                  if (!env.IsDevelopment())
                  {
                        app.UseSpaStaticFiles();
                  }

                  app.UseAuthentication();
                  app.UseRouting();
                  app.UseAuthorization();

                  app.UseEndpoints(endpoints =>
                  {
                        endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller}/{action=Index}/{id?}");

                        endpoints.MapControllerRoute(name: "apiService",
                                                      pattern: "api/{controller}/{action}");
                  });

                  app.UseSpa(spa =>
                  {
                        // To learn more about options for serving an Angular SPA from ASP.NET Core,
                        // see https://go.microsoft.com/fwlink/?linkid=864501

                        spa.Options.SourcePath = "ClientApp/App";

                        if (env.IsDevelopment())
                        {
                              spa.UseAngularCliServer(npmScript: "start");
                        }
                  });
            }
      }
}
