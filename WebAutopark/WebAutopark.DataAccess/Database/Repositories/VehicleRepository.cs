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
    public class VehicleRepository : RepositoryConnection, IRepository<Vehicle>
    {
        public VehicleRepository(IDbConnectionBuilder dbConnectionBuilder) : base(dbConnectionBuilder)
        {

        }

        public async Task Create(Vehicle entity)
        {
            const string sqlQuery =
                "INSERT INTO Vehicles" +
                "(VehicleTypeId, ModelName, RegistrationNumber, Weight, ManufactureYear, Mileage, CarColor, FuelTankAmount, Consumption) VALUES " +
                "(@VehicleTypeId, @ModelName, @RegistrationNumber, @Weight, @ManufactureYear, @Mileage, @CarColor, @FuelTankAmount, @Consumption)";

            await _connection.ExecuteAsync(sqlQuery, entity);
        }

        public async Task Delete(int id)
        {
            const string sqlQuery =
                "DELETE FROM Vehicles " +
                "WHERE Id = @id";

            await _connection.ExecuteAsync(sqlQuery, new { id });
        }

        public Task<IEnumerable<Vehicle>> GetAll()
        {
            const string sqlQuery =
                "SELECT * FROM Vehicles LEFT JOIN VehicleTypes " +
                "ON Vehicles.VehicleTypeId = VehicleTypes.Id";

            return _connection.QueryAsync<Vehicle, VehicleType, Vehicle>(sqlQuery,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    return vehicle;
                });

        }

        public async Task<Vehicle> GetById(int id)
        {
            const string sqlQuery = 
                "SELECT * FROM Vehicles vehicle " +
                "INNER JOIN VehicleTypes vehicleType " +
                "ON vehicle.VehicleTypeId = vehicleType.Id " +
                "WHERE vehicle.Id = @id";

            var queryResult = await _connection.QueryAsync<Vehicle, VehicleType, Vehicle>(sqlQuery,
                (vehicle, vehicleType) =>
                {
                    vehicle.VehicleType = vehicleType;
                    return vehicle;
                }, new { id }
           );

           return queryResult.SingleOrDefault();
        }

        public async Task Update(Vehicle entity)
        {
            const string sqlQuery =
                   "UPDATE Vehicles " +
                   "SET VehicleTypeId=@VehicleTypeId, " +
                   "ModelName=@ModelName, " +
                   "RegistrationNumber=@RegistrationNumber, " +
                   "Weight = @Weight, " +
                   "ManufactureYear = @ManufactureYear, " +
                   "Mileage = @Mileage, " +
                   "CarColor = @CarColor, " +
                   "FuelTankAmount = @FuelTankAmount " +
                   "Consumption = @Consumption " +
                   "WHERE Id = @Id";

            await _connection.ExecuteAsync(sqlQuery, entity);

        }
    }
}
