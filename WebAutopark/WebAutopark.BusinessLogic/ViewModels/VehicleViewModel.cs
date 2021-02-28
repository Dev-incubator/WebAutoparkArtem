using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class VehicleViewModel
    {
        private const double TaxMultiplier = 0.0013;
        private const double MinimumTax = 5;
        public int VehicleId { get; set; }
        public VehicleTypeViewModel VehicleType { get; set; }
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

        [Range(1, int.MaxValue)]
        public double Consumption { get; set; }
        public double? MaxKilometresRange => 100 * FuelTankAmount / Consumption;
        public double? TaxPerMonth => (Weight * TaxMultiplier) + (VehicleType?.TaxCoeff * 30) + MinimumTax;
        public string CarColor { get; set; }

    }
}
