namespace SafeVillage.VillageModule;
internal class DummySequence<T>(int id) : ISequence<T>
{
    public int GetNext()
    {
        return id;
    }
}
