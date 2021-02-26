﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;


namespace WebAutopark.DataAccess.Models
{
    public class Vehicle : Entity
    {
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public int Weight { get; set; }
        public int ManufactureYear { get; set; }
        public int Mileage { get; set; }
        public string CarColor { get; set; }
        public int FuelTankAmount { get; set; }
    }
}
