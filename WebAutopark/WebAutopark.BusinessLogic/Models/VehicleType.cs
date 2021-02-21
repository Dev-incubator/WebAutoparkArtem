using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.BusinessLogic.Models
{
    public class VehicleType : IEntity
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public double TaxCoeff { get; set; }
    }
}
