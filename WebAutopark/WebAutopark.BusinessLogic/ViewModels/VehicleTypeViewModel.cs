using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class VehicleTypeViewModel
    {
        public int VehicleTypeId { get; set; }
        [Required]
        public string TypeName { get; set; }
        [Required]
        [Range(double.Epsilon, double.MaxValue)]
        public double TaxCoeff { get; set; }
    }
}
