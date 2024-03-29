﻿using Dapper;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DBProvider
{
    public class DBDataProvider : IDBDataProvider
    {
        private readonly IConfiguration _configuration;
        public DBDataProvider(IConfiguration config)
        {
            _configuration = config;
        }

        public async Task<IEnumerable<T>> GetData<T, U>(string storedProcedure, U parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
