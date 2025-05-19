using Ardalis.GuardClauses;

namespace SafeVillage.Village;

internal class Building
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int SplendorPoints { get; private set; }
    public int Count { get; private set; } = 1;

    public Building()
    {
        
    }

    public Building(Building building)
    {
        Id = building.Id;
        Name = building.Name;
        SplendorPoints = building.SplendorPoints;
        Count = building.Count;
    }

    protected Building(int id, string name, int splendorPoints)
    {
        Id = id;
        Name = name;
        SplendorPoints = splendorPoints;
    }

    public static Building Create(ISequence<Building> sequence, string name, int splendorPoints)
    {
        sequence = Guard.Against.Null(sequence);
        name = Guard.Against.NullOrEmpty(name);
        splendorPoints = Guard.Against.Negative(splendorPoints);
        var id = Guard.Against.Negative(sequence.GetNext());

        return new(id, name, splendorPoints); 
    }

    protected void SetSplendorPoints(int value)
    {
        value = Guard.Against.Negative(value);
        SplendorPoints = value;
    }

    protected void SetCount(int value)
    {
        Count = Guard.Against.NegativeOrZero(value);
    }
}