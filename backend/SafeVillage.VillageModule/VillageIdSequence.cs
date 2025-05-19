namespace SafeVillage.VillageModule;

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