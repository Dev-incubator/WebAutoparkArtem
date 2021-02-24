using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.ViewModels;
using WebAutopark.DataAccess.Database.Repositories.Base;
using WebAutopark.DataAccess.Models;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _vehicleTypeRepository;
        private readonly IMapper _mapper;
        public VehicleTypeService(IVehicleTypeRepository vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }
        public async Task CreateVehicleType(VehicleTypeViewModel viewModel)
        {
            await _vehicleTypeRepository.CreateAsync(_mapper.Map<VehicleType>(viewModel));
        }

        public Task DeleteVehicleType(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<VehicleTypeViewModel> GetVehicleTypeById(int id)
        {
             return _mapper.Map<VehicleTypeViewModel>(await _vehicleTypeRepository.GetByIdAsync(id));
        }

        public Task<IReadOnlyCollection<VehicleTypeViewModel>> GetVehicleTypes()
        {
            throw new NotImplementedException();
        }

        public Task UpdateVehicleType(VehicleTypeViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
