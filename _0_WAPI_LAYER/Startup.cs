using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;


using EF;
using Microsoft.EntityFrameworkCore;

namespace APP
{
    public class Startup
    {

        private readonly IConfiguration Configuration;

        //private readonly IWebHostEnvironment _env;

        // ##########################################################################################
        // ##########################################################################################


        public Startup(IConfiguration configuration)//, IWebHostEnvironment env)
        {
            this.Configuration = configuration;
            //this._env = env;
        }


        // ##########################################################################################
        // ##########################################################################################


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // ------------------------------------------------------------------------------------------

            //if (_env.IsDevelopment())
            //{
            //    services.AddDbContext<WAPIContext>(options =>
            //        options.UseInMemoryDatabase("ValaisBooking"));
            //}

            // ------------------------------------------------------------------------------------------

            services.AddDbContext<WAPIContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("EFValaisBookingDB")));

            services.AddDbContext<WAPIContext>(
                options => options.LogTo(Console.WriteLine, LogLevel.Information));

            // ------------------------------------------------------------------------------------------

            services.AddControllers();

            // ------------------------------------------------------------------------------------------

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WAPI_ValaisBooking", Version = "v1" });
            });

            // ------------------------------------------------------------------------------------------
        }


        // ##########################################################################################
        // ##########################################################################################


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)//, WAPIContext WAPI)
        {
            // ------------------------------------------------------------------------------------------

            if (env.IsDevelopment())
            {
                //new DBInitializer(WAPI);
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WAPI v1"));

            }

            // ------------------------------------------------------------------------------------------

            app.UseHttpsRedirection();

            // ------------------------------------------------------------------------------------------

            app.UseRouting();

            // ------------------------------------------------------------------------------------------

            //app.UseAuthorization();

            // ------------------------------------------------------------------------------------------

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // ------------------------------------------------------------------------------------------
        }
    }
}
