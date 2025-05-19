namespace SafeVillage.VillageModule.Tests;
public class BuildingTests
{
    [Fact]
    public void Create_WhenSequenceIsNull_ThenThrowException()
    {
        ISequence<Building> invalidSequence = null!;
        var validName = "name";
        var validSplendorPoints = 10;

        Assert.ThrowsAny<Exception>(() => Building.Create(invalidSequence, validName, validSplendorPoints));
    }

    [Fact]
    public void Create_WhenIdIsNegative_ThenThrowException()
    {
        ISequence<Building> invalidSequence = new BuildingSequence(-1);
        var validName = "name";
        var validSplendorPoints = 10;

        Assert.ThrowsAny<Exception>(() => Building.Create(invalidSequence, validName, validSplendorPoints));
    }

    [Fact]
    public void Create_WhenNameIsEmpty_ThenThrowException()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var invalidName = "";
        var validSplendorPoints = 10;

        Assert.ThrowsAny<Exception>(() => Building.Create(validSequence, invalidName, validSplendorPoints));
    }

    [Fact]
    public void Create_WhenNameIsNull_ThenThrowException()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        string invalidName = null!;
        var validSplendorPoints = 10;

        Assert.ThrowsAny<Exception>(() => Building.Create(validSequence, invalidName, validSplendorPoints));
    }

    [Fact]
    public void Create_WhenSplendorPointsIsNegative_ThenThrowException()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var validName = "name";
        var invalidSplendorPoints = -1;

        Assert.ThrowsAny<Exception>(() => Building.Create(validSequence, validName, invalidSplendorPoints));
    }

    [Fact]
    public void Create_WhenValidArguments_ReturnNotNullBuilding()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var validName = "name";
        var validSplendorPoints = 10;

        var building = Building.Create(validSequence, validName, validSplendorPoints);

        Assert.NotNull(building);
    }

    [Fact]
    public void Create_WhenValidArguments_ThenBuilingStateHasSameValuesAsArguments()
    {
        var validId = 1;
        ISequence<Building> validSequence = new BuildingSequence(validId);
        var validName = "name";
        var validSplendorPoints = 10;

        var building = Building.Create(validSequence, validName, validSplendorPoints);

        Assert.Equal(validId, building.Id);
        Assert.Equal(validName, building.Name);
        Assert.Equal(validSplendorPoints, building.SplendorPoints);
    }
}
