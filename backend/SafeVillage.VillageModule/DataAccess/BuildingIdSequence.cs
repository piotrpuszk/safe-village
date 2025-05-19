using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;
internal class BuildingIdSequence(IDbContext context) : ISequence<Building>
{
    public int GetNext()
    {
        var sql = """
            select nextval('building_id_sequence')
            """;

        return context.QueryFirst<int>(sql);
    }
}
