using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAutopark.BusinessLogic.Extensions.DI;
using WebAutopark.Data.Extensions.IApplicationBuilderExtension;
using WebAutopark.DataAccess.Database.Creator;
using WebAutopark.DataAccess.Extensions.DI;

namespace WebAutopark
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            var creationScriptPath = Configuration["SqlScriptPath"];

            DbCreator.EnsureCreated(connectionString, creationScriptPath);
            services.AddDataAccess(connectionString);
            services.AddBusinessServices();
            services.AddAutomapper();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLocalization();
            app.UseCulture();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints => 
                endpoints.MapDefaultControllerRoute()
            );

        }
    }
}