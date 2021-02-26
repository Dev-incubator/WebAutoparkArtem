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
        private readonly IRepository<VehicleType> _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public VehicleTypeService(IRepository<VehicleType> vehicleTypeRepository, IMapper mapper)
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
            var mappedEntity = await _vehicleTypeRepository.GetByIdAsync(id);

            return _mapper.Map<VehicleTypeViewModel>(mappedEntity);
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetVehicleTypes()
        {
            var vehicleTypeEntities = await _vehicleTypeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypeEntities);
        }

        public Task UpdateVehicleType(VehicleTypeViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<VehicleType>(viewModel);

            return _vehicleTypeRepository.UpdateAsync(mappedEntity);
        }
    }
}
