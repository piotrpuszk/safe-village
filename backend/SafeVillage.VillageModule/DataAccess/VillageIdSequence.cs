using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;

internal class VillageIdSequence(IDbContext context) : ISequence<Village>
{
    public int GetNext()
    {
        var sql = """
            select nextval('world.location_id_sequence')
            """;

        return context.QueryFirst<int>(sql);
    }
}