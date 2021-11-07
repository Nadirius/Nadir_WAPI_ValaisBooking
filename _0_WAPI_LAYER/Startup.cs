using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EF;
using Microsoft.EntityFrameworkCore;

namespace APP
{
    public class Startup
    {

        #region Application Startup class properties

        public IConfiguration Configuration { get; }

        #endregion

        #region Application Stratup class constructor
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        #endregion

        #region Application pipeline setup (Adding pertinent middlewares to the pipeline)

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "_0_WAPI_LAYER v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #endregion

        #region Application dependencies injection & middlewares configuration

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Database service Middleware configuration

            services.AddDbContext<WAPIContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("EFValaisBookingDB")));

            services.AddDbContext<WAPIContext>(
                options => options.LogTo(Console.WriteLine, LogLevel.Information));

            #endregion

            services.AddControllers();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WAPI_ValaisBooking", Version = "v1" });
            });
        }

        #endregion

    }
}
