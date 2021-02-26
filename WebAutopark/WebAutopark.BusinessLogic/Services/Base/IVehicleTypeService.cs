using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.ViewModels;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IVehicleTypeService
    {
        Task CreateVehicleType(VehicleTypeViewModel viewModel);
        Task UpdateVehicleType(VehicleTypeViewModel viewModel);
        Task DeleteVehicleType(int id);
        Task<VehicleTypeViewModel> GetVehicleTypeById(int id);
        Task<IEnumerable<VehicleTypeViewModel>> GetVehicleTypes();
    }
}
