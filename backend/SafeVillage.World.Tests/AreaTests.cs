using SafeVillage.World.Domain;

namespace SafeVillage.World.Tests;
public class AreaTests
{
    [Fact]
    public void Create_WhenInvalidCoordinates_ThenThrowException()
    {
        Coordinates invalidCoordinates = null!;

        Assert.ThrowsAny<Exception>(() => Area.Create(invalidCoordinates));
    }

    [Fact]
    public void Create_WhenValidCoordinates_ThenCreateSuccessfully()
    {
        Coordinates validCoordinates = new(0, 0);

        _ = Area.Create(validCoordinates);
    }

    [Fact]
    public void Create_WhenValidCoordinates_ThenReturnNotNullArea()
    {
        Coordinates validCoordinates = new(0, 0);

        var area = Area.Create(validCoordinates);

        Assert.NotNull(area);
    }

    [Fact]
    public void Create_WhenValidCoordinates_ThenReturnAreaWithThisCoordinatesButDifferentReferences()
    {
        Coordinates validCoordinates = new(0, 0);

        var area = Area.Create(validCoordinates);

        Assert.False(ReferenceEquals(area.Coordinates, validCoordinates));
        Assert.Equal(validCoordinates.X, area.Coordinates.X);
        Assert.Equal(validCoordinates.Y, area.Coordinates.Y);
    }

    [Fact]
    public void Create_WhenValidLocation_ThenReturnAreaWithThisLocationButDifferentReferences()
    {
        Coordinates validCoordinates = new(0, 0);
        Location validLocation = Location.Create(1, "village");

        var area = Area.Create(validCoordinates, validLocation);

        Assert.NotNull(validLocation);
        Assert.NotNull(area.Location);
        Assert.Equal(validLocation.Id, area.Location.Id);
        Assert.Equal(validLocation.Type, area.Location.Type);
        Assert.False(ReferenceEquals(validLocation, area.Location));
    }
}
