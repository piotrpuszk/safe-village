using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.DataAccess;
internal class DummySequence<T>(int id) : ISequence<T>
{
    public int GetNext()
    {
        return id;
    }
}
