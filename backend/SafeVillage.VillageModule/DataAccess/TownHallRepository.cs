using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;

internal class TownHallRepository(IDbContext context) : ITownHallRepository
{
    public async Task<bool> AddAsync(TownHall townHall)
    {
        var sql = """
            insert into buildings(id, name, splendor_points, count) values(@Id, @Name, @SplendorPoints, @Count);
            insert into town_halls(id, level) values(@Id, @Level);
            """;

        var affected = await context.ExecuteAsync(sql, townHall);

        return affected > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = """
            delete from town_halls where id = @id;
            delete from buildings where id = @id;
            """;

        var affected = await context.ExecuteAsync(sql, new { id });

        return affected > 0;
    }

    public async Task<TownHall?> GetAsync(int id)
    {
        var sql = """
            select b.id
                ,name
                ,splendor_points splendorpoints
                ,level
                ,count
            from buildings b
                join town_halls h on h.id = b.id
            where b.id = @id
            """;

        return await context.QueryFirstOrDefaultAsync<TownHall>(sql, new { id });
    }
}