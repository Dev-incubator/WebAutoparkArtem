using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.ViewModels;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IVehicleService : IBusinessService<VehicleViewModel>
    {
        Task<IEnumerable<VehicleViewModel>> GetAllOrderedByCriteria(Func<VehicleViewModel, object> criteria);
    }
}
