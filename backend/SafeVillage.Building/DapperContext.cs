using Dapper;
using Npgsql;
using System.Data;

namespace SafeVillage.Building;
public class DapperContext : IDbContext
{
    private readonly IDbConnection _connection;
    private IDbTransaction? _transaction;

    public DapperContext(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
        _connection.Open();
    }

    public void BeginTransaction()
    {
        _transaction = _connection.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _connection.Close();
    }

    public Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
    {
        return _connection.QueryAsync<T>(sql, parameters, transaction: _transaction);
    }

    public Task<T?> QueryFirstAsync<T>(string sql, object? parameters = null)
    {
        return _connection.QueryFirstAsync<T?>(sql, parameters, transaction: _transaction);
    }

    public Task<T> QuerySingleAsync<T>(string sql, object? parameters = null)
    {
        return _connection.QuerySingleAsync<T>(sql, parameters, transaction: _transaction);
    }

    public Task ExecuteAsync(string sql, object? parameters = null)
    {
        return _connection.ExecuteAsync(sql, parameters, transaction: _transaction);
    }
}
