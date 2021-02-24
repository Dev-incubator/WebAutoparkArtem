using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.BusinessLogic.Models;
using WebAutopark.DataAccess.Database.Repositories.Base;

namespace WebAutopark.DataAccess.Database.Repositories
{
    public class VehicleTypeRepository : RepositoryConnection, IVehicleTypeRepository
    {
        public VehicleTypeRepository(IDbConnectionBuilder dbConnectionBuilder) : base(dbConnectionBuilder)
        {

        }

        public Task CreateAsync(VehicleType entity)
        {
            const string sqlQuery = 
                "INSERT INTO VehicleTypes " +
                "(TypeName, TaxCoeff) VALUES " +
                "(@TypeName,@TaxCoeff)";
            return _connection.ExecuteAsync(sqlQuery, entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleType>> GetAllAsync()
        {
            const string sqlQuery = "SELECT * FROM VehicleTypes";
            return _connection.QueryAsync<VehicleType>(sqlQuery);
        }

        public Task<VehicleType> GetByIdAsync(int id)
        {
            const string sqlQuery = "SELECT * FROM VehicleTypes WHERE Id=@id";
            return _connection.QueryFirstAsync<VehicleType>(sqlQuery, new { id });
        }

        public Task UpdateAsync(VehicleType entity)
        {
            throw new NotImplementedException();
        }
    }
}
