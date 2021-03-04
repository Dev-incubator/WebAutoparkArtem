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
    public class OrderService : IBusinessService<OrderViewModel>
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public Task Create(OrderViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<Order>(viewModel);

            return _orderRepository.Create(mappedEntity);
        }

        public Task Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAll()
        {
            var ordersListEntities = await _orderRepository.GetAll();

            var ordersViewModels = _mapper.Map<IEnumerable<OrderViewModel>>(ordersListEntities);

            return ordersViewModels;

        }

        public async Task<OrderViewModel> GetById(int id)
        {
            var foundedEntity = await _orderRepository.GetById(id);

            return _mapper.Map<OrderViewModel>(foundedEntity);
        }

        public Task Update(OrderViewModel viewModel)
        {
            var mappedEntity = _mapper.Map<Order>(viewModel);

            return _orderRepository.Update(mappedEntity);
        }
    }
}
