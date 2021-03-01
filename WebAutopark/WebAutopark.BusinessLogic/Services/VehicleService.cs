using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.ViewModels;
using WebAutopark.DataAccess.Database.Repositories.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehicleService : IVehicleService
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

            return _vehicleRepository.Create(vehicle);
        }

        public Task Delete(int id)
        {
            return _vehicleRepository.Delete(id);
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAll()
        {
            var vehicleEntities = await _vehicleRepository.GetAll();

            return _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleEntities);
        }

        public async Task<IEnumerable<VehicleViewModel>> GetAllOrderedByCriteria(Func<VehicleViewModel, object> criteria)
        {
            var vehicleEntities = await _vehicleRepository.GetAll();

            var viewModelsList = _mapper.Map<IEnumerable<VehicleViewModel>>(vehicleEntities);

            return viewModelsList.OrderBy(criteria).ToList();
        }

        public async Task<VehicleViewModel> GetById(int id)
        {
            var foundedVehicle = await _vehicleRepository.GetById(id);

            return _mapper.Map<VehicleViewModel>(foundedVehicle);
        }

        public Task Update(VehicleViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<Vehicle>(viewModel);

            return _vehicleRepository.Update(mappedEntity);
        }
    }
}
