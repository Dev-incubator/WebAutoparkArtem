using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutopark.DataAccess.Database.Repositories.Base
{
    public abstract class RepositoryConnection : IDisposable, IAsyncDisposable
    {
        private readonly DbConnection _connection;
        protected RepositoryConnection(IDbConnectionBuilder connectionBuilder)
        {
            _connection = connectionBuilder.GetConnection();
        }

        public void Dispose() => _connection.Dispose();

        public ValueTask DisposeAsync() => _connection.DisposeAsync();
    }
}
