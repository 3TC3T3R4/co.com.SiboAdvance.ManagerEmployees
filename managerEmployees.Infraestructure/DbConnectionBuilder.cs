using managerEmployees.Infraestructure.SqlAdapter.Gateway;
using Microsoft.Data.SqlClient;
using System.Data;

namespace managerEmployees.Infraestructure
{
    public class DbConnectionBuilder : IDbConnectionBuilder

    {
        private readonly string _connectionString;
        public DbConnectionBuilder(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;






        }
    }
}