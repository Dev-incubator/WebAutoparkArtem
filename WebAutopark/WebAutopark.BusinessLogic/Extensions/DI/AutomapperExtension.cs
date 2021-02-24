using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.BusinessLogic.ViewModels;

namespace WebAutopark.BusinessLogic.Extensions.DI
{
    public static class AutomapperExtension
    {
        public static void AddAutomapper(this IServiceCollection services)
        {
            services.AddAutoMapper(
                cfg =>
                {
                    cfg.CreateMap<VehicleType, VehicleTypeViewModel>()
                    .ForMember(dest => dest.VehicleTypeId, act => act.MapFrom(src => src.Id));

                    cfg.CreateMap<VehicleTypeViewModel, VehicleType>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.VehicleTypeId));
                }
            );
        }
    }
}
