using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    public class Order : Entity
    {
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public string Description { get; set; }
    }
}
