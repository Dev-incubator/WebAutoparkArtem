using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{

    /// <summary>
    /// Interface with base CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        /// Get all entities from database
        /// </summary>
        /// <returns>List of all entities</returns>
        Task<IEnumerable<T>> GetAll(); 

        /// <summary>
        /// Create new entity in database 
        /// </summary>
        /// <param name="entity"></param>
        Task Create(T entity);

        /// <summary>
        /// Update entity in database
        /// </summary>
        /// <param name="entity"></param>
        Task Update(T entity);

        /// <summary>
        /// Delete entity from database by id
        /// </summary>
        /// <param name="id"></param>
        /// 
        Task Delete(int id);
        /// <summary>
        /// Find entity by id
        /// </summary>
        /// <param name="id"></param>
        Task<T> GetById(int id);
    }
}
