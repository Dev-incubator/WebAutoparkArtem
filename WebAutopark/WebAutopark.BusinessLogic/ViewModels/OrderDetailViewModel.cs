using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class OrderDetailViewModel
    {
        public int OrderDetailId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public VehiclePartViewModel Part { get; set; }
        [Required]
        public int PartId { get; set; }

        [Range(1, int.MaxValue)]
        public int PartAmount { get; set; }
    }
}
