using Ardalis.GuardClauses;
using SafeVillage.Village.Exceptions;

namespace SafeVillage.Village;
internal class House : Building
{
    public int Capacity { get; private set; } = _capacity;
    public int NumberOfInhabitants { get; private set; }
    
    public new const string Name = "House";
    private const int _capacity = 10;

    public House()
    {
        
    }

    private House(ISequence<Building> sequence, int numberOfInhabitants) : base(sequence, Name, 0)
    {
        NumberOfInhabitants = numberOfInhabitants;
    }

    public static House Create(ISequence<Building> sequence, int numberOfInhabitants)
    {
        numberOfInhabitants = Guard.Against.Negative(numberOfInhabitants);
        sequence = Guard.Against.Null(sequence);

        if (numberOfInhabitants > _capacity)
        {
            throw new NumberOfInhabitantsIsGreaterThanHouseCapacityException(Name, _capacity, numberOfInhabitants);
        }

        House house = new(sequence, numberOfInhabitants);
        house.UpdateSplendorPoints();

        return house;
    }

    public void IncreaseNumberOfInhabitants(int value)
    {
        var newValue = NumberOfInhabitants + value;
        NumberOfInhabitants = Guard.Against.OutOfRange(newValue, nameof(value), 0, Capacity);
        UpdateSplendorPoints();
    }

    private int CalculateSplendorPoints()
    {
        return NumberOfInhabitants;
    }

    private void UpdateSplendorPoints()
    {
        var value = CalculateSplendorPoints();
        SetSplendorPoints(value);
    }
}
