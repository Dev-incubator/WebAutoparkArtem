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
    public class VehiclePartRepository : RepositoryConnection, IRepository<VehiclePart>
    {
        public VehiclePartRepository(IDbConnectionBuilder dbConnectionBuilder) : base(dbConnectionBuilder)
        {

        }

        public Task Create(VehiclePart entity)
        {
            const string sqlQuery =
                "INSERT INTO VehicleParts " +
                "(Name, Amount, Price, Description) VALUES " +
                "(@Name, @Amount, @Price, @Description)";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }

        public Task Delete(int id)
        {
            var sqlQuery = "DELETE FROM VehicleParts WHERE Id = @id";

            return _connection.ExecuteAsync(sqlQuery, new { id });
        }

        public Task<IEnumerable<VehiclePart>> GetAll()
        {
            const string sqlQuery = "SELECT * FROM VehicleParts";

            return _connection.QueryAsync<VehiclePart>(sqlQuery);
        }

        public Task<VehiclePart> GetById(int id)
        {
            const string sqlQuery = "SELECT * FROM VehicleParts WHERE Id=@id";

            return _connection.QueryFirstAsync<VehiclePart>(sqlQuery, new { id });
        }

        public Task Update(VehiclePart entity)
        {
            const string sqlQuery =
                "UPDATE VehicleParts " +
                "SET Name = @Name, Amount = @Amount, Price = @Price, Description = @Description " +
                "WHERE Id = @Id";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }
    }
}
