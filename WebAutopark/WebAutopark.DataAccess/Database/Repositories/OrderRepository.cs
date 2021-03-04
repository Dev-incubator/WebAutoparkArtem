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
    /// Repository to work with orders
    /// </summary>
    public class OrderRepository : RepositoryConnection, IRepository<Order>
    {
        public OrderRepository(IDbConnectionBuilder connectionBuilder) : base(connectionBuilder)
        {

        }

        /// <summary>
        /// Load orders from db with included data
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <param name="param"></param>
        /// <returns>IEnumerable with all orders and included data</returns>
        private async Task<IEnumerable<Order>> GetOrders(string sqlQuery, object param = null)
        {
            var queryResult = await _connection.QueryAsync<Order, OrderDetail, VehiclePart, Vehicle, (Order order, OrderDetail orderDetail)>(sqlQuery,
                (order, orderDetail, vehiclePart, vehicle) =>
                {
                    order.Vehicle = vehicle;

                    if (orderDetail is not null && vehiclePart is not null)
                    {
                        orderDetail.Part = vehiclePart;
                    }

                    return (order, orderDetail);
                }, param);

            var groupedQueryResult = queryResult.GroupBy(key => key.order.Id).Select(tuple =>
            {
                var selectResult = queryResult.First().order;

                selectResult.OrderDetails =
                (queryResult.Select(tuple => tuple.orderDetail)
                .Where(orderDetail => orderDetail is not null))
                .ToList();

                return selectResult;
            });

            return groupedQueryResult;
        }

        public Task Create(Order entity)
        {
            const string sqlQuery =
                "INSERT INTO Orders " +
                "(VehicleId, Description) VALUES" +
                "(@VehicleId, @Description)";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }

        public Task Delete(int id)
        {
            const string sqlQuery =
                "DELETE FROM Orders " +
                "WHERE Id = @id";

            return _connection.ExecuteAsync(sqlQuery, new { id });
        }

        public Task<IEnumerable<Order>> GetAll()
        {
            const string sqlQuery =
                "SELECT o.*, od.*, vp.*, v.* FROM ORDERS o " +
                "LEFT JOIN OrderDetails od on o.Id = od.OrderId " +
                "LEFT JOIN VehicleParts vp on od.PartId = vp.Id " +
                "INNER JOIN Vehicles v on v.Id = o.VehicleId";

            return GetOrders(sqlQuery);
        }

        public async Task<Order> GetById(int id)
        {
            const string sqlQuery =
                "SELECT o.*, od.*, vp.*, v.* FROM ORDERS o " +
                "LEFT JOIN OrderDetails od on o.Id = od.OrderId " +
                "LEFT JOIN VehicleParts vp on od.PartId = vp.Id " +
                "INNER JOIN Vehicles v on v.Id = o.VehicleId " +
                "WHERE o.Id = @id";

            var queryResult = await GetOrders(sqlQuery, new { id });

            return queryResult.SingleOrDefault();
        }

        public Task Update(Order entity)
        {
            const string sqlQuery =
                "UPDATE Orders SET " +
                "VehicleId = @VehicleId, " +
                "Description = @Description " +
                "WHERE Id = @Id";

            return _connection.ExecuteAsync(sqlQuery, entity);
        }
    }
}
