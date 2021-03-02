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
        public VehiclePart VehiclePart { get; set; }
        public int DetailId { get; set; }
        public int DetailAmount { get; set; }
    }
}
