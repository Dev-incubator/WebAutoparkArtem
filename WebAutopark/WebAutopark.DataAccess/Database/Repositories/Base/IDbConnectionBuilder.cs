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
    /// Interface for providing DB connection
    /// </summary>
    public interface IDbConnectionBuilder
    {

        /// <summary>
        /// Create a new DB connection
        /// </summary>
        /// <returns>DbConnection instance</returns>
        DbConnection GetConnection();
    }
}
