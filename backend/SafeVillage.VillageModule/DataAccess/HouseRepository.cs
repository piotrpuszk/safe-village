using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;

internal class HouseRepository(IDbContext context) : IHouseRepository
{
    public async Task<bool> AddAsync(House house)
    {
        var sql = """
            insert into buildings(id, name, splendor_points, count) values(@Id, @Name, @SplendorPoints, @Count);
            insert into houses(id, capacity, number_of_inhabitants) values(@Id, @Capacity, @NumberOfInhabitants);
            """;

        var affected = await context.ExecuteAsync(sql, house);

        return affected > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = """
            delete from houses where id = @id;
            delete from buildings where id = @id;
            """;

        var affected = await context.ExecuteAsync(sql, new { id });

        return affected > 0;
    }

    public async Task<House?> GetAsync(int id)
    {
        var sql = """
            select b.id
                ,name
                ,splendor_points splendorpoints
                ,capacity
                ,number_of_inhabitants numberofinhabitants
                ,count
            from buildings b
                join houses h on h.id = b.id
            where b.id = @id
            """;

        return await context.QueryFirstOrDefaultAsync<House>(sql, new { id });
    }
}
