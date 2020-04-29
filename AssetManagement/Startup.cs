using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AssetManagement.Model.DBContext;
using AssetManagement.Facade.Interface;
using AssetManagement.DAL.Interface;
using AssetManagement.BLL.Interface;
using AssetManagement.Facade;
using AssetManagement.DAL;
using AssetManagement.BLL;

namespace AssetManagement
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
            // in production, the angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "clientapp/dist";
            });
            services.AddDbContext<AssetDBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("AssetDBConnection"));
            });

            services.AddTransient<ICustomerDAL, CustomerDAL>();
            services.AddTransient<ICustomerBLL, CustomerBLL>();
            services.AddTransient<ICustomerFacade, CustomerFacade>();
            services.AddTransient<IAssetDAL, AssetDAL>();
            services.AddTransient<IAssetBLL, AssetBLL>();
            services.AddTransient<IAssetFacade, AssetFacade>();
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
            }

            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
