namespace SafeVillage.Village;
public interface IDbContext : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null);
    Task<T?> QueryFirstAsync<T>(string sql, object? parameters = null);

    Task<T> QuerySingleAsync<T>(string sql, object? parameters = null);
    Task ExecuteAsync(string sql, object? parameters = null);
    T QueryFirst<T>(string sql, object? parameters = null);
}
