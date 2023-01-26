using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFileUploadLib
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            this._config = config;
        }
        public async Task SaveData(string storeProc, string connectionName, object parameters)
        {
            string connString = _config.GetConnectionString(connectionName) ?? throw new Exception($"Missing connection string at {connectionName}");

            using var connection = new SqlConnection(connString);
            await connection.ExecuteAsync(
                storeProc,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<List<T>> LoadData<T>(string storeProc, string connectionName, object? parameters)
        {
            string connString = _config.GetConnectionString(connectionName) ?? throw new Exception($"Missing connection string at {connectionName}");

            using var connection = new SqlConnection(connString);

            var rows = await connection.QueryAsync<T>(storeProc,
                parameters,
                commandType: System.Data.CommandType.StoredProcedure);

            return rows.ToList();
        }

    }
}
