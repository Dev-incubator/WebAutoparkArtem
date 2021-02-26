using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Models
{
    public class VehicleType : Entity
    {
        public string TypeName { get; set; }
        public double TaxCoeff { get; set; }
    }
}
