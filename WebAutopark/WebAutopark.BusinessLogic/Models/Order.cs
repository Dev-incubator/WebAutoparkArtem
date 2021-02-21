using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.BusinessLogic.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Description { get; set; }
    }
}
