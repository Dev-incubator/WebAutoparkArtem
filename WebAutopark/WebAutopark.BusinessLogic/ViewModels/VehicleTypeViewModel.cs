using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class VehicleTypeViewModel
    {
        public int VehicleTypeId { get; set; }
        public string TypeName { get; set; }
        public double TaxCoeff { get; set; }
    }
}
