using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutopark.DataAccess.Database.Repositories.Base;
using WebAutopark.DataAccess.Entities;

namespace WebAutopark.DataAccess.Database.Repositories
{
    public class VehicleTypeRepository : RepositoryConnection, IRepository<VehicleType>
    {
        public VehicleTypeRepository(IDbConnectionBuilder dbConnectionBuilder) : base(dbConnectionBuilder)
        {

        }

        public Task Create(VehicleType entity)
        {
            const string sqlQuery =
                "INSERT INTO VehicleTypes " +
                "(TypeName, TaxCoeff) VALUES " +
                "(@TypeName, @TaxCoeff)";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }

        public Task Delete(int id)
        {
            var sqlQuery = "DELETE FROM VehicleTypes WHERE Id = @id";

            return _connection.ExecuteAsync(sqlQuery, new { id });
        }

        public Task<IEnumerable<VehicleType>> GetAll()
        {
            const string sqlQuery = "SELECT * FROM VehicleTypes";

            return _connection.QueryAsync<VehicleType>(sqlQuery);
        }

        public Task<VehicleType> GetById(int id)
        {
            const string sqlQuery = "SELECT * FROM VehicleTypes WHERE Id=@id";

            return _connection.QueryFirstAsync<VehicleType>(sqlQuery, new { id });
        }

        public Task Update(VehicleType entity)
        {
            const string sqlQuery =
                "UPDATE VehicleTypes " +
                "SET TypeName = @TypeName, TaxCoeff = @TaxCoeff " +
                "WHERE Id = @Id";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }
    }
}
