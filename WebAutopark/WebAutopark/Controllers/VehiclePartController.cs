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
    public class VehiclePartController : Controller
    {
        private readonly IBusinessService<VehiclePartViewModel> _vehiclePartService;

        public VehiclePartController(IBusinessService<VehiclePartViewModel> vehiclePartService)
        {
            _vehiclePartService = vehiclePartService;
        }

        public async Task<IActionResult> View(int id)
        {
            var foundedPart = await _vehiclePartService.GetById(id);

            if (foundedPart is null)
            {
                return NoContent();
            }

            return View(foundedPart);
        }

        public async Task<IActionResult> ViewList()
        {
            var vehicleList = await _vehiclePartService.GetAll();

            if (vehicleList is null)
            {
                return NoContent();
            }

            return View(vehicleList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehiclePartViewModel viewModel)
        {
            await _vehiclePartService.Create(viewModel);

            return RedirectToAction("ViewList");
        }

        public async Task<IActionResult> Update(int id)
        {
            var foundedUpdatePart = await _vehiclePartService.GetById(id);

            if (foundedUpdatePart is null)
            {
                return NoContent();
            }

            return View(foundedUpdatePart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehiclePartViewModel viewModel)
        {
            await _vehiclePartService.Update(viewModel);

            return RedirectToAction("ViewList");
        }

        public async Task<IActionResult> DeleteConfirmation(int id)
        {
            var foundedDeletePart = await _vehiclePartService.GetById(id);

            if (foundedDeletePart is null)
            {
                return NoContent();
            }

            return View(foundedDeletePart);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _vehiclePartService.Delete(id);

            return RedirectToAction("ViewList");
        }
    }
}
