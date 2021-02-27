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
    public class VehicleService : IBusinessService<VehicleViewModel>
    {
        private readonly IRepository<Vehicle> _vehicleRepository;
        private readonly IMapper _mapper;

        public VehicleService(IRepository<Vehicle> repository, IMapper mapper)
        {
            _vehicleRepository = repository;
            _mapper = mapper;
        }

        public Task Create(VehicleViewModel viewModel)
        {
            var vehicle = _mapper.Map<Vehicle>(viewModel);

            return _vehicleRepository.CreateAsync(vehicle);
        }

        public Task Delete(int id)
        {
            return _vehicleRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAll()
        {
            var vehicleEntities = await _vehicleRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleEntities);
        }

        public async Task<VehicleViewModel> GetById(int id)
        {
            var foundedVehicle = await _vehicleRepository.GetByIdAsync(id);

            return _mapper.Map<VehicleViewModel>(foundedVehicle);
        }

        public Task Update(VehicleViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<Vehicle>(viewModel);

            return _vehicleRepository.UpdateAsync(mappedEntity);
        }
    }
}
