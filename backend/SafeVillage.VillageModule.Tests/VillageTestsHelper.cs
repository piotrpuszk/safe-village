using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

internal class VillageSequence(int id) : ISequence<Village>
{
    public int GetNext()
    {
        return id;
    }
}

internal class BuildingSequence(int id) : ISequence<Building>
{
    public int GetNext()
    {
        return id;
    }
}
