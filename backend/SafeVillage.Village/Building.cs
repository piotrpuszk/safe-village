namespace SafeVillage.Village;

internal abstract class Building(ISequence<Building> sequence, string name, int splendorPoints)
{
    public int Id { get; init; } = sequence.GetNext();
    public string Name { get; init; } = name;
    public int SplendorPoints { get; private set; } = splendorPoints;

    protected void UpdateSplendorPoints()
    {
        SplendorPoints = CalculateSplendorPoints();
    }

    protected abstract int CalculateSplendorPoints();
}