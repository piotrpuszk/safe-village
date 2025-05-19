namespace SafeVillage.Village.Tests;
public class VillageTests
{
    [Fact]
    public void Create_WhenSequenceIsNull_ThenThrowException()
    {
        ISequence<Village> sequence = null!;
        Building[] validBuildings = [];
        var validName = "name";

        Assert.ThrowsAny<Exception>(() => Village.Create(sequence, validName, validBuildings));
    }

    [Fact]
    public void Create_WhenNegativeId_ThenThrowException()
    {
        var invalidId = -1;
        var sequence = new VillageSequence(invalidId);
        Building[] validBuildings = [];
        var validName = "name";

        Assert.ThrowsAny<Exception>(() => Village.Create(sequence, validName, validBuildings));
    }

    [Fact]
    public void Create_WhenNameIsNull_ThenThrowException()
    {
        var validId = 1;
        VillageSequence sequence = new(validId);
        Building[] validBuildings = [];
        string invalidName = null!;

        Assert.ThrowsAny<Exception>(() => Village.Create(sequence, invalidName, validBuildings));
    }

    [Fact]
    public void Create_WhenNameIsEmpty_ThenThrowException()
    {
        var validId = 1;
        VillageSequence sequence = new(validId);
        Building[] validBuildings = [];
        string invalidName = string.Empty;

        Assert.ThrowsAny<Exception>(() => Village.Create(sequence, invalidName, validBuildings));
    }

    [Fact]
    public void Create_WhenBuildingListIsNull_ThenThrowException()
    {
        var validId = 1;
        VillageSequence sequence = new(validId);
        Building[] invalidBuildings = null!;
        string validName = "name";

        Assert.ThrowsAny<Exception>(() => Village.Create(sequence, validName, invalidBuildings));
    }

    [Fact]
    public void Create_WhenValidArguments_ThenReturnNotNullVillage()
    {
        var validId = 1;
        VillageSequence sequence = new(validId);
        Building[] validBuildings = [];
        string validName = "name";

        var village = Village.Create(sequence, validName, validBuildings);

        Assert.NotNull(village);
    }

    [Fact]
    public void Create_WhenValidArguments_ThenReturnVillageWithGivenValues()
    {
        var validId = 1;
        VillageSequence sequence = new(validId);
        Building[] validBuildings = [Building.Create(new BuildingSequence(1), "building", 5)];
        string validName = "name";

        var village = Village.Create(sequence, validName, validBuildings);

        Assert.Equal(village.Name, validName);
        Assert.Equal(validBuildings.Length, village.Buildings.Count);
        foreach (var building in validBuildings)
        {
            Assert.Contains(building.Id, village.Buildings.Select(e => e.Id));
            Assert.Contains(building.Name, village.Buildings.Select(e => e.Name));
            Assert.Contains(building.SplendorPoints, village.Buildings.Select(e => e.SplendorPoints));
            Assert.Contains(building.Count, village.Buildings.Select(e => e.Count));
        }
    }

    [Fact]
    public void Create_WhenValidArguments_ThenReturnVillageWithDifferentReferences()
    {
        var validId = 1;
        VillageSequence sequence = new(validId);
        Building[] validBuildings = [Building.Create(new BuildingSequence(1), "building", 5)];
        string validName = "name";

        var village = Village.Create(sequence, validName, validBuildings);

        Assert.False(ReferenceEquals(village.Buildings, validBuildings));

        foreach (var building in validBuildings)
        {
            var referenceExists = village.Buildings.Any(e => ReferenceEquals(e, building));
            Assert.False(referenceExists);
        }
    }
}
