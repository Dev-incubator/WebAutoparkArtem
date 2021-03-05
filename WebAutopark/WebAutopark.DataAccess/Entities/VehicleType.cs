using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Entities
{
    /// <summary>
    /// Vehicle type entity
    /// </summary>
    public class VehicleType : Entity
    {
        /// <summary>
        /// Name of type
        /// </summary>
        public string TypeName { get; set; }
        /// <summary>
        /// Tax coefficent 
        /// </summary>
        public double TaxCoeff { get; set; }
    }
}
