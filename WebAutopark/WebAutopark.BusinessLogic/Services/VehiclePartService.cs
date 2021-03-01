using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.ViewModels;
using WebAutopark.DataAccess.Database.Repositories.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services
{
    public class VehiclePartService : IBusinessService<VehiclePartViewModel>
    {
        private readonly IRepository<VehiclePart> _vehiclePartRepository;
        private readonly IMapper _mapper;

        public VehiclePartService(IRepository<VehiclePart> vehiclePartRepository, IMapper mapper)
        {
            _vehiclePartRepository = vehiclePartRepository;
            _mapper = mapper;
        }

        public Task Create(VehiclePartViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<VehiclePart>(viewModel);

            return _vehiclePartRepository.Create(mappedEntity);

        }

        public Task Delete(int id)
        {
            return _vehiclePartRepository.Delete(id);
        }

        public async Task<IEnumerable<VehiclePartViewModel>> GetAll()
        {
            var vehiclePartsList = await _vehiclePartRepository.GetAll();

            return _mapper.Map<IEnumerable<VehiclePartViewModel>>(vehiclePartsList);
        }

        public async Task<VehiclePartViewModel> GetById(int id)
        {
            var foundedEntity = await _vehiclePartRepository.GetById(id);

            return _mapper.Map<VehiclePartViewModel>(foundedEntity);
        }

        public Task Update(VehiclePartViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<VehiclePart>(viewModel);

            return _vehiclePartRepository.Update(mappedEntity);
        }
    }
}
