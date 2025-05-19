using SafeVillage.WildernessModule.Domain;
using SafeVillage.WildernessModule.Interfaces;

namespace SafeVillage.WildernessModule.DataAccess;
internal class WildernessSequence(IDbContext context) : ISequence<Wilderness>
{
    public int GetNext()
    {
        return context.QueryFirst<int>("""select nextval('world.location_id_sequence')""");
    }
}
