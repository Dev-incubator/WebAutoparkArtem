using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.ViewModels;

namespace WebAutopark.Controllers
{
    public class OrderDetailController : Controller
    {

        private readonly IBusinessService<VehiclePartViewModel> _vehiclePartService;
        private readonly IBusinessService<OrderDetailViewModel> _orderDetailService;

        public OrderDetailController(IBusinessService<VehiclePartViewModel> vehiclePartService, IBusinessService<OrderDetailViewModel> orderDetailService)
        {
            _vehiclePartService = vehiclePartService;
            _orderDetailService = orderDetailService;
        }

        private async Task<SelectList> GetSelectListWithVehicleParts()
        {
            var vehiclePartList = await _vehiclePartService.GetAll();

            return new SelectList(vehiclePartList, "VehiclePartId", "Name");
        }

        [HttpGet]
        public async Task<IActionResult> Create(int orderId)
        {

            ViewBag.Parts = await GetSelectListWithVehicleParts();

            var viewModel = new OrderDetailViewModel
            {
                OrderId = orderId
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderDetailViewModel viewModel)
        {

            await _orderDetailService.Create(viewModel);

            return RedirectToAction("View", "Order", new { id = viewModel.OrderId });
        }

        public async Task<IActionResult> Update(int id)
        {
            var orderDetail = await _orderDetailService.GetById(id);

            if (orderDetail is null)
            {
                return NoContent();
            }

            ViewBag.Parts = await GetSelectListWithVehicleParts();


            return View(orderDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OrderDetailViewModel viewModel)
        {
            await _orderDetailService.Update(viewModel);

            return RedirectToAction("View", "Order", new { id = viewModel.OrderId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, int orderId)
        {
            await _orderDetailService.Delete(id);

            return RedirectToAction("View", "Order", new { id = orderId });
        }
    }
}
