using CoffeeShop.Models;
using CoffeeShop.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoffeeShop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region For Creating Migration
            //// extract connection string from appconfiguration.json
            //string connectionStr = Configuration.GetConnectionString("DefaultConnection");

            //// adding connection to data base like service
            //services.AddDbContext<DataContext>(
            //    options => options.UseSqlServer(connectionStr));
            #endregion

            // add minimum mvc parts
            services.AddControllersWithViews();

            services.AddScoped<IRepository, SqlRepository>();
            services.AddTransient<IOrder, OrderService>();
            services.AddTransient<IOrderValidate, OrderValidateService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Create}/{id?}");
            });
        }
    }
}
