using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Database.Repositories;
using WebAutopark.DataAccess.Database.Repositories.Base;
using WebAutopark.DataAccess.Models;

namespace WebAutopark.DataAccess.Extensions.DI
{
    public static class DataAccessExtension
    {
        public static void AddDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDbConnectionBuilder, DbConnectionBuilder>(provider => new DbConnectionBuilder(connectionString));
            services.AddScoped<IRepository<VehicleType>, VehicleTypeRepository>();
            services.AddScoped<IRepository<Vehicle>, VehicleRepository>();
        }
    }
}
