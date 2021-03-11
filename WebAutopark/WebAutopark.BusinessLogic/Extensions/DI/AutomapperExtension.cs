using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.ViewModels;
using WebAutopark.DataAccess.Entities;

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
                    .ForMember(dest => dest.VehicleTypeId, act => act.MapFrom(src => src.Id))
                    .ReverseMap();


                    cfg.CreateMap<Vehicle, VehicleViewModel>()
                    .ForMember(dest => dest.VehicleId, act => act.MapFrom(src => src.Id))
                    .ReverseMap();


                    cfg.CreateMap<VehiclePart, VehiclePartViewModel>()
                    .ForMember(dest => dest.VehiclePartId, act => act.MapFrom(src => src.Id))
                    .ReverseMap();


                    cfg.CreateMap<OrderDetail, OrderDetailViewModel>()
                    .ForMember(dest => dest.OrderDetailId, act => act.MapFrom(src => src.Id))
                    .ReverseMap();


                    cfg.CreateMap<Order, OrderViewModel>()
                    .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.Id))
                    .ReverseMap();


                }
            );
        }
    }
}
