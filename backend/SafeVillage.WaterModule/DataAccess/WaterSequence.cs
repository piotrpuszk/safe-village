using SafeVillage.WaterModule.Domain;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.DataAccess;
internal class WaterSequence(IDbContext context) : ISequence<Water>
{
    public int GetNext()
    {
        return context.QueryFirst<int>("""select nextval('world.location_id_sequence')""");
    }
}
