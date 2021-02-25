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
        // GET: VehicleTypeController/View/5
        public async Task<IActionResult> View(int id)
        {
            var vehicleType = await _vehicleTypeService.GetById(id);

            if (vehicleType is null)
            {
                return NoContent();
            }

            return View(vehicleType);
        }

        // GET: VehicleTypeController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleTypeViewModel viewModel)
        {
            await _vehicleTypeService.Create(viewModel);

            return RedirectToAction("ViewList");
        }

        // GET: VehicleTypeController/Update/5
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var vehicleType = await _vehicleTypeService.GetById(id);

            if (vehicleType is null)
            {
                return NoContent();
            }

            return View(vehicleType);
        }

        // POST: VehicleTypeController/Update/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehicleTypeViewModel viewModel)
        {
            await _vehicleTypeService.Update(viewModel);

            return RedirectToAction("ViewList");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var vehicleType = await _vehicleTypeService.GetById(id);

            if (vehicleType is null)
            {
                return NoContent();
            }

            return View(vehicleType);
        }

        // POST: VehicleTypeController/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehicleTypeService.Delete(id);

            return RedirectToAction("ViewList");
        }

    }
}
