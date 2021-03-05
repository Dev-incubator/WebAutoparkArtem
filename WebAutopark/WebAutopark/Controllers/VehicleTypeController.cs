using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Services.Base;
using WebAutopark.BusinessLogic.ViewModels;

namespace WebAutopark.Controllers
{
    public class VehicleTypeController : Controller
    {
        private readonly IBusinessService<VehicleTypeViewModel> _vehicleTypeService;

        public VehicleTypeController(IBusinessService<VehicleTypeViewModel> vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public async Task<IActionResult> ViewList()
        {
            var vehicleTypesList = await _vehicleTypeService.GetAll();

            return View(vehicleTypesList);
        }

        public async Task<IActionResult> View(int id)
        {
            var vehicleType = await _vehicleTypeService.GetById(id);

            if (vehicleType is null)
            {
                return NoContent();
            }

            return View(vehicleType);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleTypeViewModel viewModel)
        {
            await _vehicleTypeService.Create(viewModel);

            return RedirectToAction(nameof(ViewList));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var updateVehicleType = await _vehicleTypeService.GetById(id);

            if (updateVehicleType is null)
            {
                return NoContent();
            }

            return View(updateVehicleType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehicleTypeViewModel viewModel)
        {
            await _vehicleTypeService.Update(viewModel);

            return RedirectToAction(nameof(ViewList));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var deleteVehicleType = await _vehicleTypeService.GetById(id);

            if (deleteVehicleType is null)
            {
                return NoContent();
            }

            return View(deleteVehicleType);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleTypeService.Delete(id);

            return RedirectToAction(nameof(ViewList));
        }

    }
}
