using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.DataAccess.Models;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class VehicleViewModel
    {
        public VehicleViewModel()
        {

        }
        public VehicleViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            VehicleTypeId = vehicle.VehicleTypeId;
            ModelName = vehicle.ModelName;
            RegistrationNumber = vehicle.RegistrationNumber;
            Weight = vehicle.Weight;
            ManufactureYear = vehicle.ManufactureYear;
            Mileage = vehicle.Mileage;
            FuelTankAmount = vehicle.FuelTankAmount;
            CarColor = vehicle.CarColor;
        }
        public int Id { get; set; }
        public int VehicleTypeId { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string RegistrationNumber { get; set; }
        [Required]
        public int Weight { get; set; }
        [Range(1800, int.MaxValue)]
        [Required]
        public int ManufactureYear { get; set; }
        [Range(0, int.MaxValue)]
        [Required]
        public int Mileage { get; set; }
        [Required]
        public int FuelTankAmount { get; set; }
        public string CarColor { get; set; }

    }
}
