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

        public async Task CreateAsync(VehicleType entity)
        {
            const string sqlQuery =
                "INSERT INTO VehicleTypes " +
                "(TypeName, TaxCoeff) VALUES " +
                "(@TypeName, @TaxCoeff)";

            await _connection.ExecuteAsync(sqlQuery, entity);
        }

        public Task DeleteAsync(int id)
        {
            var sqlQuery = "DELETE FROM VehicleTypes WHERE Id = @id";

            return _connection.ExecuteAsync(sqlQuery, new { id });
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
            const string sqlQuery = 
                "UPDATE VehicleTypes " +
                "SET TypeName = @TypeName, TaxCoeff = @TaxCoeff " +
                "WHERE Id = @Id";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }
    }
}
