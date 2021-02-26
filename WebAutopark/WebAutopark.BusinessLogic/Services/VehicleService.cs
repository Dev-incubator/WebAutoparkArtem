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

        public async Task Create(VehicleViewModel viewModel)
        {
            var vehicle = _mapper.Map<VehicleViewModel, Vehicle>(viewModel);

            await _vehicleRepository.CreateAsync(vehicle);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAll()
        {
            var vehicleEntities = await _vehicleRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Vehicle>, IEnumerable<VehicleViewModel>>(vehicleEntities);
        }

        public async Task<VehicleViewModel> GetById(int id)
        {
            var findedVehicle = await _vehicleRepository.GetByIdAsync(id);

            return _mapper.Map<Vehicle, VehicleViewModel>(findedVehicle);
        }

        public async Task Update(VehicleViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<VehicleViewModel, Vehicle>(viewModel);

            await _vehicleRepository.UpdateAsync(mappedEntity);
        }
    }
}
