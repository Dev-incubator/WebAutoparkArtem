using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{
    public interface IRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAll(); 
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
        Task<T> GetById(int id);
    }
}
