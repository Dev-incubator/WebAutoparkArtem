using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    public class VehiclePart : Entity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
    }
}
