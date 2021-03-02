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
                    .ForMember(dest => dest.VehicleTypeId, act => act.MapFrom(src => src.Id));

                    cfg.CreateMap<VehicleTypeViewModel, VehicleType>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.VehicleTypeId));

                    cfg.CreateMap<Vehicle, VehicleViewModel>()
                    .ForMember(dest => dest.VehicleId, act => act.MapFrom(src => src.Id));

                    cfg.CreateMap<VehicleViewModel, Vehicle>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.VehicleId));

                    cfg.CreateMap<VehiclePart, VehiclePartViewModel>()
                    .ForMember(dest => dest.VehiclePartId, act => act.MapFrom(src => src.Id));

                    cfg.CreateMap<VehiclePartViewModel, VehiclePart>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.VehiclePartId));

                    cfg.CreateMap<OrderDetail, OrderDetailViewModel>()
                    .ForMember(dest => dest.OrderDetailId, act => act.MapFrom(src => src.Id));

                    cfg.CreateMap<OrderDetailViewModel, OrderDetail>()
                    .ForMember(dest => dest.Id, act => act.MapFrom(src => src.OrderDetailId));

                }
            );
        }
    }
}
