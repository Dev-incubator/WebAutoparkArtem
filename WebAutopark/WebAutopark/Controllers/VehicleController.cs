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
    public class VehicleController : Controller
    {
        private readonly IBusinessService<VehicleViewModel> _vehicleService;
        private readonly IBusinessService<VehicleTypeViewModel> _vehicleTypeService;

        public VehicleController(
            IBusinessService<VehicleViewModel> vehicleService, 
            IBusinessService<VehicleTypeViewModel> vehicleTypeService)
        {
            _vehicleService = vehicleService;
            _vehicleTypeService = vehicleTypeService;
        }

        public async Task<IActionResult> View(int id)
        {
            var vehicle = await _vehicleService.GetById(id);

            if (vehicle is null)
            {
                return NoContent();
            }

            return View(vehicle);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var vehicle = await _vehicleService.GetById(id);

            if (vehicle is null)
            {
                return NoContent();
            }

            var vehicleTypes = await _vehicleTypeService.GetAll();
            ViewBag.Types = new SelectList(vehicleTypes, "VehicleTypeId", "TypeName", vehicle.VehicleType);

            return View(vehicle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehicleViewModel viewModel)
        {
            await _vehicleService.Update(viewModel);

            return RedirectToAction("ViewList");
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var vehicleTypes = await _vehicleTypeService.GetAll();
            ViewBag.Types = new SelectList(vehicleTypes, "VehicleTypeId", "TypeName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel viewModel)
        {

            await _vehicleService.Create(viewModel);

            return RedirectToAction("ViewList");
        }

        public async Task<IActionResult> ViewList()
        {
            var vehicleList = await _vehicleService.GetAll();

            return View(vehicleList);

        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var deletedVehicle = await _vehicleService.GetById(id);

            if (deletedVehicle is null)
            {
                return NoContent();
            }

            return View(deletedVehicle);
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleService.Delete(id);

            return RedirectToAction("ViewList");
        }
    }
}
