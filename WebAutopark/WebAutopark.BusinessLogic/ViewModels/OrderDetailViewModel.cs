using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public VehiclePartViewModel Part { get; set; }
        public int PartId { get; set; }
        public int PartAmount { get; set; }
    }
}
