namespace SafeVillage.WildernessModule;
internal class WildernessSequence(IDbContext context) : ISequence<Wilderness>
{
    public int GetNext()
    {
        return context.QueryFirst<int>("""select nextval('world.location_id_sequence')""");
    }
}
