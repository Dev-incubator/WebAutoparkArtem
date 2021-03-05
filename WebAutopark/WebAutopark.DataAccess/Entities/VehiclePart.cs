using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    /// <summary>
    /// Vehicle part enitiy
    /// </summary>
    public class VehiclePart : Entity
    {
        /// <summary>
        /// Name of part
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Price of part
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Amount of part in warehouse
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Short description of part
        /// </summary>
        public string Description { get; set; }
    }
}
