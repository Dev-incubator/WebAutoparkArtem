using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.BusinessLogic.ViewModels
{
    public class VehiclePartViewModel
    {
        public int VehiclePartId { get; set; }
        [Required]
        public string Name { get; set; }
        [Range(1, int.MaxValue)]
        public int Amount { get; set; }
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
