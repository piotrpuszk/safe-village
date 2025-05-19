using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;

internal class VillageRepository(IDbContext context) : IVillageRepository
{
    public async Task<bool> AddAsync(Village village)
    {
        var sql = """
            insert into villages(id, name) values(@Id, @Name)
            """;

        var villagesAffected = await context.ExecuteAsync(sql, village);

        if (villagesAffected == 0)
        {
            return false;
        }    

        var villageBuildingSql = """
            insert into villages_buildings(village_id, building_id) values(@VillageId, @BuildingId)
            """;

        foreach (var building in village.Buildings)
        {
            var buildingAffected = await context.ExecuteAsync(villageBuildingSql, new { VillageId = village.Id, BuildingId = building.Id });

            if (buildingAffected == 0)
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var sql = """
            delete from villages where id = @id;
            delete from villages_buildings where village_id = @id
            """;

        var affected = await context.ExecuteAsync(sql, new { id });

        return affected > 0;
    }

    public async Task<Village?> GetAsync(int villageId, IReadOnlyCollection<Building> buildings)
    {
        var sql = """
            select id
                ,name
            from villages
            where id = @villageId
            """;

        return await context.QueryFirstOrDefaultAsync<Village>(sql, new { villageId });
    }
}
