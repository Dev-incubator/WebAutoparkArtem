using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    public class OrderDetail : Entity
    {
        public int OrderId { get; set; }
        public VehiclePart Part { get; set; }
        public int PartId { get; set; }
        public int PartAmount { get; set; }
    }
}
