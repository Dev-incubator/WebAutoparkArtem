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
    public class OrderDetailService : IBusinessService<OrderDetailViewModel>
    {

        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IRepository<OrderDetail> orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public Task Create(OrderDetailViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<OrderDetail>(viewModel);

            return _orderDetailRepository.Create(mappedEntity);
        }

        public Task Delete(int id)
        {
            return _orderDetailRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderDetailViewModel>> GetAll()
        {
            var orderDetailEntities = await _orderDetailRepository.GetAll();

            var viewModelList = _mapper.Map<IEnumerable<OrderDetailViewModel>>(orderDetailEntities);

            return viewModelList;
        }

        public async Task<OrderDetailViewModel> GetById(int id)
        {
            var foundedEntity = await _orderDetailRepository.GetById(id);

            return _mapper.Map<OrderDetailViewModel>(foundedEntity);
        }

        public Task Update(OrderDetailViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<OrderDetail>(viewModel);

            return _orderDetailRepository.Update(mappedEntity);
        }
    }
}
