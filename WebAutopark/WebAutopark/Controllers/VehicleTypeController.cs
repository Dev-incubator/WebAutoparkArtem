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
        private readonly IVehicleTypeService _vehicleTypeService;
        public VehicleTypeController(IVehicleTypeService vehicleTypeService)
        {
            _vehicleTypeService = vehicleTypeService;
        }

        public async Task<IActionResult> ViewList()
        {
            return View(await _vehicleTypeService.GetVehicleTypes());
        }
        // GET: VehicleTypeController/Details/5
        public async Task<IActionResult> View(int id)
        {
            return View(await _vehicleTypeService.GetVehicleTypeById(id));
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
            await _vehicleTypeService.CreateVehicleType(viewModel);

            return RedirectToAction("ViewList");
        }

        // GET: VehicleTypeController/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            return View(await _vehicleTypeService.GetVehicleTypeById(id));
        }

        // POST: VehicleTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(VehicleTypeViewModel viewModel)
        {
            await _vehicleTypeService.UpdateVehicleType(viewModel);

            return RedirectToAction("ViewList");
        }

    }
}
