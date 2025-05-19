namespace SafeVillage.World.Tests;
public class WorldTests
{
    [Fact]
    public void Create_WhenNegativeId_ThenThrowValidationError()
    {
        var invalidId = -1;
        List<Area> validAreas = [];

        Assert.ThrowsAny<Exception>(() => World.Create(invalidId, validAreas));
    }

    [Fact]
    public void Create_WhenAreasEqualNull_ThenThrowValidationError()
    {
        var validId = 1;
        List<Area> invalidAreas = null!;

        Assert.ThrowsAny<Exception>(() => World.Create(validId, invalidAreas));
    }

    [Fact]
    public void Create_ValidArguments_CreateWithoutException()
    {
        var validId = 1;
        List<Area> validAreas = [];

        var result = World.Create(validId, validAreas);
    }

    [Fact]
    public void Create_ValidArguments_ReturnNotNullWorld()
    {
        var validId = 1;
        List<Area> validAreas = [];

        var result = World.Create(validId, validAreas);

        Assert.NotNull(result);
    }

    [Fact]
    public void Create_ValidId_ReturnWorldWithProvidedId()
    {
        var validId = 1;
        List<Area> validAreas = [];

        var result = World.Create(validId, validAreas);

        Assert.Equal(validId, result.Id);
    }

    [Fact]
    public void Create_AreasWithOneArea_ReturnWorldWithSameStateButDifferentReferences()
    {
        var validId = 1;
        var area = Area.Create(new(1, 1), Location.Create(1, "village"));
        List<Area> validAreas =
            [
                area,
            ];

        var world = World.Create(validId, validAreas);
        var actual = world.Areas[0];

        Assert.NotNull(area);
        Assert.NotNull(actual);
        Assert.NotNull(area.Location);
        Assert.NotNull(actual.Location);
        Assert.Equal(area.Coordinates.X, actual.Coordinates.X);
        Assert.Equal(area.Coordinates.Y, actual.Coordinates.Y);
        Assert.Equal(area.Location.Id, actual.Location.Id);
        Assert.Equal(area.Location.Type, actual.Location.Type);
        Assert.False(ReferenceEquals(area, world.Areas[0]));
        Assert.False(ReferenceEquals(area.Location, actual.Location));
    }
}
