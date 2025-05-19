namespace SafeVillage.Wilderness;

internal class WildernessRepository(IDbContext context) : IWildernessRepository
{
    public async Task<bool> AddAsync(Wilderness wilderness)
    {
        return await context.ExecuteAsync("""insert into wildernesses(id, inhabit_points) values(@Id, @InhabitPoints)""", wilderness) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await context.ExecuteAsync("""delete from wildernesses where id = @Id""", new { id }) > 0;
    }

    public Task<Wilderness?> GetAsync(int id)
    {
        return context.QueryFirstOrDefaultAsync<Wilderness>("""
            select id
                ,inhabit_points inhabitpoints
            from wildernesses
            where id = @id
            """, new { id });
    }
}
