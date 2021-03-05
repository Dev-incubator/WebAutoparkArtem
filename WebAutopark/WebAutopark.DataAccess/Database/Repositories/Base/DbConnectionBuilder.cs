using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{

    /// <summary>
    /// Parent class with 
    /// </summary>
    public class DbConnectionBuilder : IDbConnectionBuilder
    {

        private readonly string _connectionString;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="connectionString"></param>
        public DbConnectionBuilder(string connectionString)
        {
            _connectionString = connectionString;
        }

        /// <summary>
        /// Create sql connection instance
        /// </summary>
        /// <returns>New sql connection</returns>
        public DbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
