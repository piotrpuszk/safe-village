using System.Runtime.InteropServices;

namespace SafeVillage.Village;

internal class VillageRepository(IDbContext context) : IVillageRepository
{
    public async Task AddAsync(Village village)
    {
        var sql = """
            insert into villages(id, name) values(@Id, @Name)
            """;

        await context.ExecuteAsync(sql, village);

        var villageBuildingSql = """
            insert into villages_buildings(village_id, building_id) values(@VillageId, @BuildingId)
            """;

        foreach (var building in village.Buildings)
        {
            await context.ExecuteAsync(villageBuildingSql, new { VillageId = village.Id, BuildingId = building.Id });
        }
    }

    public Task DeleteAsync(int id)
    {
        var sql = """
            delete from villages where id = @id;
            delete from villages_buildings where village_id = @id
            """;

        return context.ExecuteAsync(sql, new { id });
    }

    public async Task<Village> GetAsync(int villageId, IReadOnlyCollection<Building> buildings)
    {
        var sql = """
            select id
                ,name
            from villages
            where id = @villageId
            """;

        var (id, name) = await context.QueryFirstAsync<(int id, string name)>(sql, new { villageId });

        return Village.Create(new DummySequence<Village>(id), name, buildings);
    }
}
