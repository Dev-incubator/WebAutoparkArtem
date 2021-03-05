using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;


namespace WebAutopark.DataAccess.Entities
{
    /// <summary>
    /// Vehicle entity
    /// </summary>
    public class Vehicle : Entity
    {
        /// <summary>
        /// Vehicle type instance
        /// </summary>
        public VehicleType VehicleType { get; set; }
        /// <summary>
        /// Vehicle type id (part of One-To-Many relationship)
        /// </summary>
        public int VehicleTypeId { get; set; }
        /// <summary>
        /// Name of vehicle model
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// Registration number of a vehicle
        /// </summary>
        public string RegistrationNumber { get; set; }
        /// <summary>
        /// Vehicle weight in Kg
        /// </summary>
        public int Weight { get; set; }
        /// <summary>
        /// Year of production
        /// </summary>
        public int ManufactureYear { get; set; }
        /// <summary>
        /// Vehicle mileage in Km
        /// </summary>
        public int Mileage { get; set; }
        /// <summary>
        /// Vehicle color
        /// </summary>
        public string CarColor { get; set; }
        /// <summary>
        /// Fuel tank amount
        /// </summary>
        public int FuelTankAmount { get; set; }
        /// <summary>
        /// Consumption of vehicle engine
        /// </summary>
        public double Consumption { get; set; }
    }
}
