using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.ViewModels;
using WebAutopark.DataAccess.Database.Repositories.Base;
using WebAutopark.DataAccess.Models;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleTypeService : IBusinessService<VehicleTypeViewModel>
    {
        private readonly IRepository<VehicleType> _vehicleTypeRepository;
        private readonly IMapper _mapper;

        public VehicleTypeService(IRepository<VehicleType> vehicleTypeRepository, IMapper mapper)
        {
            _vehicleTypeRepository = vehicleTypeRepository;
            _mapper = mapper;
        }

        public Task Create(VehicleTypeViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<VehicleType>(viewModel);

            return _vehicleTypeRepository.CreateAsync(mappedEntity);
        }

        public Task Delete(int id)
        {
            return _vehicleTypeRepository.DeleteAsync(id);
        }

        public async Task<VehicleTypeViewModel> GetById(int id)
        {
            var foundedEntity = await _vehicleTypeRepository.GetByIdAsync(id);

            return _mapper.Map<VehicleTypeViewModel>(foundedEntity);
        }

        public async Task<IEnumerable<VehicleTypeViewModel>> GetAll()
        {
            var vehicleTypeEntities = await _vehicleTypeRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<VehicleTypeViewModel>>(vehicleTypeEntities);
        }

        public Task Update(VehicleTypeViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<VehicleType>(viewModel);

            return _vehicleTypeRepository.UpdateAsync(mappedEntity);
        }
    }
}
