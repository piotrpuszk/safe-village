namespace SafeVillage.World;
internal interface IDbContext<TContext> : IDisposable
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null);
    Task<T?> QueryFirstAsync<T>(string sql, object? parameters = null);

    Task<T> QuerySingleAsync<T>(string sql, object? parameters = null);
}
