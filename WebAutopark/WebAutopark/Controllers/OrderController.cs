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
    public class OrderController : Controller
    {

        private readonly IBusinessService<OrderViewModel> _orderService;
        private readonly IVehicleService _vehicleService;

        public OrderController(IBusinessService<OrderViewModel> orderService, IVehicleService vehicleService)
        {
            _orderService = orderService;
            _vehicleService = vehicleService;
        }

        private async Task<SelectList> GetSelectListWithVehicles(object defaultChoice = null)
        {
            var vehicleList = await _vehicleService.GetAll();

            return new SelectList(vehicleList, "VehicleId", "ModelName", defaultChoice);
        }

        public async Task<IActionResult> ViewList()
        {
            var ordersList = await _orderService.GetAll();

            return View(ordersList);
        }

        public async Task<IActionResult> View(int id)
        {
            var foundedEntity = await _orderService.GetById(id);

            if (foundedEntity is null)
            {
                return NoContent();
            }

            return View(foundedEntity);
        }

        public async Task<IActionResult> Create()
        {
            var selectList = await GetSelectListWithVehicles();

            ViewBag.Vehicles = selectList;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel viewModel)
        {
            await _orderService.Create(viewModel);

            return RedirectToAction(nameof(ViewList));
        }

        public async Task<IActionResult> Update(int id)
        {
            var updatedEntity = await _orderService.GetById(id);

            if (updatedEntity is null)
            {
                return NoContent();
            }

            ViewBag.Vehicles = await GetSelectListWithVehicles(updatedEntity.Vehicle);

            return View(updatedEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(OrderViewModel viewModel)
        {

            await _orderService.Update(viewModel);

            return RedirectToAction(nameof(ViewList));
        }

        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var deletedEntity = await _orderService.GetById(id);

            if (deletedEntity is null)
            {
                return NoContent();
            }

            return View(deletedEntity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {

            await _orderService.Delete(id);

            return RedirectToAction(nameof(ViewList));
        }
    }
}
