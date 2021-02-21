using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{
    public interface IDbConnectionBuilder
    {
        DbConnection GetConnection();
    }
}
