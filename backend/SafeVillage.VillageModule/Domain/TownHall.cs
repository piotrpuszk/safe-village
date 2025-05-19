using Ardalis.GuardClauses;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.Domain;
internal class TownHall : Building, ILevelable
{
    public int Level { get; private set; } = _initialLevel;

    private const int _splendorMultiplierBase = 5;
    private const int _initialLevel = 1;
    public new const string Name = "Town Hall";

    public TownHall(int id) : base(id, Name, 0)
    {
    }

    public static TownHall Create(ISequence<Building> sequence)
    {
        sequence = Guard.Against.Null(sequence);
        var id = Guard.Against.Negative(sequence.GetNext());

        TownHall townHall = new(id);
        townHall.UpdateSplendorPoints();

        return townHall;
    }

    public void LevelUp()
    {
        ++Level;
        UpdateSplendorPoints();
    }

    private  int CalculateSplendorPoints()
    {
        return Level * _splendorMultiplierBase;
    }

    private void UpdateSplendorPoints()
    {
        var value = CalculateSplendorPoints();
        SetSplendorPoints(value);
    }
}
