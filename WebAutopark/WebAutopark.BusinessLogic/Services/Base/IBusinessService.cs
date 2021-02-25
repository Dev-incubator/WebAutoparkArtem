using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.BusinessLogic.Services.Base
{
    public interface IBusinessService<T> 
        where T : class
    {
        Task Create(T viewModel);
        Task Update(T viewModel);
        Task Delete(int id);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
