using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using ComputerMonitorStockManager.Middlewares;
using ComputerMonitorStockManager.Logging;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DBRepositories;
using DataAccessLayer.InMemoryRepositories;
using ServiceLayer.Services;
using ServiceLayer.Interfaces;


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
            
            services.AddControllersWithViews();

            services.AddScoped<IManufacturerService, ManufacturerService>();
            services.AddScoped<IMonitorService, MonitorService>();
            
            services.AddSingleton<ILogging, LoggingNLog>();

            //LIST
            //services.AddSingleton<IMonitorsRepository, MonitorsListRepository>();
            //services.AddSingleton<IManufacturersRepository, ManufacturersListRepository>();

            //DB
            services.AddSingleton<IMonitorsRepository, MonitorsDBRepository>();
            services.AddSingleton<IManufacturersRepository, ManufacturersDBRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ComputerMonitorStockManager", Version = "v1" });
                c.EnableAnnotations();
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
                endpoints.MapControllerRoute(name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }


    }
}
