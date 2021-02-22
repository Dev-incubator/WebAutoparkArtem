using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.ViewModels;

namespace WebAutopark.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult ViewVehicles()
        {
            return View(new List<VehicleViewModel> 
            {
                new VehicleViewModel
                {
                    Id = 1,
                    VehicleTypeId = 2,
                    FuelTankAmount = 50,
                    ManufactureYear = 2020,
                    Mileage = 350000,
                    ModelName = "Volkswagen",
                    RegistrationNumber = "AX5555",
                    CarColor = "Red",
                    Weight = 1500

                },
                new VehicleViewModel
                {
                    Id = 2,
                    VehicleTypeId = 1,
                    FuelTankAmount = 50,
                    ManufactureYear = 2020,
                    Mileage = 350000,
                    ModelName = "Test2",
                    RegistrationNumber = "AX5555",
                    CarColor = "Blue",
                    Weight = 1500

                },
                new VehicleViewModel
                {
                    Id = 2,
                    VehicleTypeId = 1,
                    FuelTankAmount = 50,
                    ManufactureYear = 2020,
                    Mileage = 350000,
                    ModelName = "Test2",
                    RegistrationNumber = "AX5555",
                    CarColor = "Blue",
                    Weight = 1500

                }
            });
        }
    }
}
