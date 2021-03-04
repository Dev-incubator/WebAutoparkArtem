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
    /// <summary>
    /// Repository to work with order details
    /// </summary>
    public class OrderDetailRepository : RepositoryConnection, IRepository<OrderDetail>
    {
        public OrderDetailRepository(IDbConnectionBuilder dbConnectionBuilder) : base(dbConnectionBuilder)
        {

        }

        public Task Create(OrderDetail entity)
        {
            const string sqlQuery =
                "INSERT INTO OrderDetails " +
                "(OrderId, PartId, PartAmount) VALUES" +
                "(@OrderId, @PartId, @PartAmount)";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }

        public Task Delete(int id)
        {
            const string sqlQuery =
                "DELETE FROM OrderDetails " +
                "WHERE Id = @id";

            return _connection.ExecuteAsync(sqlQuery, new { id });
        }

        public Task<IEnumerable<OrderDetail>> GetAll()
        {
            const string sqlQuery =
                "SELECT od.*, vp.* FROM OrderDetails od " +
                "LEFT JOIN VehicleParts vp on od.PartId = vp.Id ";

            return _connection.QueryAsync<OrderDetail, VehiclePart, OrderDetail>(sqlQuery, (orderDetail, part) =>
            {
                orderDetail.Part = part;
                return orderDetail;
            });
        }

        public async Task<OrderDetail> GetById(int id)
        {
            const string sqlQuery =
                "SELECT od.*, vp.* FROM OrderDetails od " +
                "LEFT JOIN VehicleParts vp on od.PartId = vp.Id " +
                "WHERE od.Id = @id";

            var queryResult = await _connection.QueryAsync<OrderDetail, VehiclePart, OrderDetail>(sqlQuery, (orderDetail, part) =>
            {
                orderDetail.Part = part;
                return orderDetail;
            }, new { id });

            return queryResult.SingleOrDefault();
        }

        public Task Update(OrderDetail entity)
        {
            const string sqlQuery =
                "UPDATE OrderDetails SET " +
                "PartId = @PartId " +
                "PartAmount = @PartAmount " +
                "WHERE Id = @Id";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }
    }
}
