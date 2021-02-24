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
            var mappedEntity = _mapper.Map<VehicleType>(viewModel);
            await _vehicleTypeRepository.CreateAsync(mappedEntity);
        }

        public async Task DeleteVehicleType(int id)
        {
            await _vehicleTypeRepository.DeleteAsync(id);
        }

        public async Task<VehicleTypeViewModel> GetVehicleTypeById(int id)
        {
             return _mapper.Map<VehicleTypeViewModel>(await _vehicleTypeRepository.GetByIdAsync(id));
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetVehicleTypes()
        {
            return _mapper.Map<IEnumerable<VehicleTypeViewModel>>(await _vehicleTypeRepository.GetAllAsync());
        }

        public Task UpdateVehicleType(VehicleTypeViewModel viewModel)
        {
            return _vehicleTypeRepository.UpdateAsync(_mapper.Map<VehicleType>(viewModel));
        }
    }
}
