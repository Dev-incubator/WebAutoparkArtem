using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    /// <summary>
    /// Order entity
    /// </summary>
    public class Order : Entity
    {
        /// <summary>
        /// Id of vehicle
        /// </summary>
        public int VehicleId { get; set; }
        /// <summary>
        /// Instance of vehicle
        /// </summary>
        public Vehicle Vehicle { get; set; }
        /// <summary>
        /// List of order details (Part of Many-To-Many relationship)
        /// </summary>
        public List<OrderDetail> OrderDetails { get; set; }

        /// <summary>
        /// Short description about order
        /// </summary>
        public string Description { get; set; }
    }
}
