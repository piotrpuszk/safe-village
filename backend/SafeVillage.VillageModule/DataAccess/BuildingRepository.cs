using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;

internal class BuildingRepository(IDbContext context) : IBuildingRepository
{
    public async Task<IReadOnlyCollection<Building>> GetVillageBuildingsAsync(int villageId)
    {
        var sql = $"""
            select b.id
                ,name
                ,splendor_points splendorpoints
                ,count
            from buildings b
                join villages_buildings vb on vb.building_id = b.id
            where vb.village_id = @villageId
            """;

        return (await context.QueryAsync<Building>(sql, new { villageId })).ToList().AsReadOnly();

    }
}
