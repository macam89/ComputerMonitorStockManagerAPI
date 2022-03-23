using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ComputerMonitorStockManager.Models;
using ComputerMonitorStockManager.Middlewares;
using Microsoft.AspNetCore.Authorization;
using ComputerMonitorStockManager.Logging;
using NLog;

namespace ComputerMonitorStockManager
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

            services.AddControllers();
            services.AddSingleton<ILogging, LoggingNLog>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ComputerMonitorStockManager", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogging logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ComputerMonitorStockManager v1"));
            }

            app.UseHttpsRedirection();

            app.ExceptionHandler(logger);

            app.UseRouting();

            app.UseMiddleware<BasicAuthMiddleware>("");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public static List<Manufacturers> manufacurers = new List<Manufacturers>()
        {
            new Manufacturers() {Name = "HP", PhoneNumber = "1234"},
            new Manufacturers() {Name = "Dell", PhoneNumber = "+5678"},
            new Manufacturers() {Name = "Asus", PhoneNumber = "876/54321"},
        };

        public static List<Monitors> monitors = new List<Monitors>()
        {
            new Monitors() {Model = "9RV17AA", Size = "23,8 inch", Color = "black", Price = "25500 RSD", ManufactureName = "HP", Resolution = "1920 x 1080 px", IsFullHD = true},
            new Monitors() {Model = "SE2722H", Size = "27 inch", Color = "black", Price = "26600 RSD", ManufactureName = "Dell", Resolution = "1920 x 1080 px", IsFullHD = false},
            new Monitors() {Model = "S2422HG", Size = "24 inch", Color = "black", Price = "38800 RSD", ManufactureName = "Dell", Resolution = "1920 x 1080 px", IsFullHD = true},
            new Monitors() {Model = "VA24EHE", Size = "23,8 inch", Color = "black", Price = "22200 RSD", ManufactureName = "Asus", Resolution = "1920 x 1080 px", IsFullHD = true},

        };
    }
}
