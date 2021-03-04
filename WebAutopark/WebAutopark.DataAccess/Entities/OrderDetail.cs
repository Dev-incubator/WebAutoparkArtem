using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    /// <summary>
    /// Class, that represent order detail
    /// </summary>
    public class OrderDetail : Entity
    {
        /// <summary>
        /// Id of order (part of Many-To-Many relationship)
        /// </summary>
        public int OrderId { get; set; }
        /// <summary>
        /// Vehicle part instance
        /// </summary>
        public VehiclePart Part { get; set; }

        /// <summary>
        /// Id of vehicle part
        /// </summary>
        public int PartId { get; set; }
        /// <summary>
        /// Amount of ordered parts
        /// </summary>
        public int PartAmount { get; set; }
    }
}
