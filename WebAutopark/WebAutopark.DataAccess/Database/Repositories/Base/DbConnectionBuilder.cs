using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{
    public class DbConnectionBuilder : IDbConnectionBuilder
    {
        private readonly string _connectionString;
        public DbConnectionBuilder(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
