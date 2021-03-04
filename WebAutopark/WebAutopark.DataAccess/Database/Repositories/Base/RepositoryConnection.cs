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
    /// Abstract class, that provides DbConnection
    /// </summary>
    public abstract class RepositoryConnection : IDisposable, IAsyncDisposable
    {
        protected readonly DbConnection _connection;

        protected RepositoryConnection(IDbConnectionBuilder connectionBuilder)
        {
            _connection = connectionBuilder.GetConnection();
        }

        public void Dispose() => _connection.Dispose();

        public ValueTask DisposeAsync() => _connection.DisposeAsync();
    }
}
