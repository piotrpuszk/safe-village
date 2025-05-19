using SafeVillage.Village;

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
