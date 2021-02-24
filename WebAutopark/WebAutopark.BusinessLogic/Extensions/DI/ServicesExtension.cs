using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services;
using WebAutopark.BusinessLogic.Services.Base;

namespace WebAutopark.BusinessLogic.Extensions.DI
{
    public static class ServicesExtension
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IVehicleTypeService, VehicleTypeService>();
        }
    }
}
