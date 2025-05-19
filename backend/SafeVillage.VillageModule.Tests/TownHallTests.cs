namespace SafeVillage.VillageModule.Tests;
public class TownHallTests
{
    [Fact]
    public void Create_WhenSequenceIsNull_ThenThrowException()
    {
        ISequence<Building> invalidSequence = null!;

        Assert.ThrowsAny<Exception>(() => TownHall.Create(invalidSequence));
    }

    [Fact]
    public void Create_WhenIdIsNegative_ThenThrowException()
    {
        ISequence<Building> invalidSequence = new BuildingSequence(-1);

        Assert.ThrowsAny<Exception>(() => TownHall.Create(invalidSequence));
    }

    [Fact]
    public void Create_WhenValidId_ThenReturnNotNullTownHall()
    {

        ISequence<Building> validSequence = new BuildingSequence(1);

        var townHall = TownHall.Create(validSequence);

        Assert.NotNull(townHall);
    }

    [Fact]
    public void LevelUp_WhenInvoked_ThenIncreaseLevelByOne()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var townHall = TownHall.Create(validSequence);
        var currentLevel = townHall.Level;

        townHall.LevelUp();

        Assert.Equal(currentLevel + 1, townHall.Level);
    }

    [Fact]
    public void LevelUp_WhenInvoked_ThenIncreaseSplendorPoints()
    {
        ISequence<Building> validSequence = new BuildingSequence(1);
        var townHall = TownHall.Create(validSequence);
        var currentSplendorPoints = townHall.SplendorPoints;

        townHall.LevelUp();

        Assert.True(townHall.SplendorPoints > currentSplendorPoints);
    }
}
