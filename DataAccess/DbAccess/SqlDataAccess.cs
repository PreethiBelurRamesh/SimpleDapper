using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config=config;
    }



    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedprocedure,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storedprocedure, parameters,
            commandType: CommandType.StoredProcedure);

    }

    public async Task SaveData<T>(
          string storedprocedure,
          T parameters,
          string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        await connection.ExecuteAsync(storedprocedure, parameters,
            commandType: CommandType.StoredProcedure);

    }

    public async Task<T> SingleValue<T, U>(
        string sqlQuery, 
        U parameters, 
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));

        return await connection.ExecuteScalarAsync<T>(sqlQuery,parameters);
    }

    public async Task<IEnumerable<T>> MultipleRows<T, U>(
        string sqlQuery,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(sqlQuery, parameters);
    }

    public async Task InsertSingleRow<U>(
        string sqlQuery,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        await connection.ExecuteAsync(sqlQuery,parameters);
    }

    public async Task<int> InsertReturnRowsAffected<U>(
    string sqlQuery,
    U parameters,
    string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.ExecuteAsync(sqlQuery, parameters);
    }
}
