﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Entities.Base;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{
    interface IRepository<T> where T : IEntity
    {
        Task<IReadOnlyCollection<T>> GetAllAsync(); 
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(int id);
    }
}
