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

    protected Building(ISequence<Building> sequence, string name, int splendorPoints)
    {
        Id = sequence.GetNext();
        Name = name;
        SplendorPoints = splendorPoints;
    }

    public static Building Create(ISequence<Building> sequence, string name, int splendorPoints)
    {
        sequence = Guard.Against.Null(sequence);
        name = Guard.Against.NullOrEmpty(name);
        splendorPoints = Guard.Against.Negative(splendorPoints);

        return new(sequence, name, splendorPoints); 
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