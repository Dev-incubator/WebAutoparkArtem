using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace WebAutopark.DataAccess.Database.Creator
{
    public static class DbCreator
    {
        private const string SqlExtension = ".sql";
        public static void EnsureCreated(string connectionString, string sqlPath)
        {
            var name = new SqlConnectionStringBuilder(connectionString).InitialCatalog;
            connectionString = new SqlConnectionStringBuilder(connectionString) 
            { 
                InitialCatalog = string.Empty
            }.ToString();

            using var serverConnection = new SqlConnection(connectionString);
            var server = new Server(new ServerConnection(serverConnection));

            if (!server.Databases.Contains(name))
            {

                if (File.Exists(sqlPath) && Path.GetExtension(sqlPath) == SqlExtension)
                {
                    var sqlScript = File.ReadAllText(sqlPath).Replace("DataBaseName", name);
                    server.ConnectionContext.ExecuteNonQuery(sqlScript);
                }

                else
                {
                    throw new ArgumentException("Sql path isn't valid!", nameof(sqlPath));
                }

            }

        }
    }
}
