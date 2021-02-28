using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class VehiclePartViewModel
    {
        public int VehiclePartId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
