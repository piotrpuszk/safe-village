using SafeVillage.VillageModule.Domain;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.Tests;
public class HouseTests
{
    [Fact]
    public void Create_WhenSequenceIsNull_ThenThrowException()
    {
        ISequence<Building> invalidSequence = null!;
        var validNumberOfInhabitants = 1;

        Assert.ThrowsAny<Exception>(() => House.Create(invalidSequence, validNumberOfInhabitants));
    }

    [Fact]
    public void Create_WhenIdIsNegative_ThenThrowException()
    {
        ISequence<Building> invalidSequence = new BuildingSequence(-1);
        var validNumberOfInhabitants = 1;

        Assert.ThrowsAny<Exception>(() => House.Create(invalidSequence, validNumberOfInhabitants));
    }

    [Fact]
    public void Create_WhenValidId_ThenReturnNotNullTownHall()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var validNumberOfInhabitants = 1;

        var townHall = House.Create(validSequence, validNumberOfInhabitants);

        Assert.NotNull(townHall);
    }

    [Fact]
    public void Create_WhenGivenNumberOfInhabitantsIsGreaterThanCapacity_ThenThrowException()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var invalidNumberOfInhabitants = 10_000;

        Assert.ThrowsAny<Exception>(() => House.Create(validSequence, invalidNumberOfInhabitants));
    }

    [Fact]
    public void Create_WhenGivenNumberOfInhabitantsIsNegative_ThenThrowException()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var invalidNumberOfInhabitants = -1;

        Assert.ThrowsAny<Exception>(() => House.Create(validSequence, invalidNumberOfInhabitants));
    }

    [Fact]
    public void Create_WhenValidArguments_ThenReturnNotNullHouse()
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);
        var validNumberOfInhabitants = 1;

        var house = House.Create(validSequence, validNumberOfInhabitants);

        Assert.NotNull(house);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(2)]
    public void Create_WhenValidArguments_ThenReturnHouseWithGivenValues(int validNumberOfInhabitants)
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);

        var house = House.Create(validSequence, validNumberOfInhabitants);

        Assert.Equal(validId, house.Id);
        Assert.Equal(validNumberOfInhabitants, house.NumberOfInhabitants);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(10)]
    [InlineData(10000)]
    public void IncreaseNumberOfInhabitants_WhenInvalidValue_ThenThrowException(int invalidValue)
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);
        var validNumberOfInhabitants = 1;

        var house = House.Create(validSequence, validNumberOfInhabitants);

        Assert.ThrowsAny<Exception>(() => house.IncreaseNumberOfInhabitants(invalidValue));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(9)]
    public void IncreaseNumberOfInhabitants_WhenValidValue_ThenCorrectlySetNumberOfInhabitants(int validValue)
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);
        var validNumberOfInhabitants = 1;

        var house = House.Create(validSequence, validNumberOfInhabitants);

        house.IncreaseNumberOfInhabitants(validValue);

        Assert.Equal(validNumberOfInhabitants + validValue, house.NumberOfInhabitants);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Add_WhenInvalidValue_ThenThrowException(int invalidValue)
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);
        var validNumberOfInhabitants = 1;

        var house = House.Create(validSequence, validNumberOfInhabitants);

        Assert.ThrowsAny<Exception>(() => house.Add(invalidValue));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(9)]
    public void IncreaseNumberOfInhabitants_WhenValidValue_ThenCorrectlySetCount(int validValue)
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);
        var validNumberOfInhabitants = 1;

        var house = House.Create(validSequence, validNumberOfInhabitants);

        var expected = house.Count + validValue;

        house.Add(validValue);

        Assert.Equal(expected, house.Count);
    }
}
