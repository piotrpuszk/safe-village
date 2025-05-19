using SafeVillage.WorldModule.Domain;

namespace SafeVillage.WorldModule.Tests;
public class LocationTests
{
    [Fact]
    public void Create_WhenNegativeId_ThenThrowException()
    {
        var negativeId = -1;
        var validType = "village";

        Assert.ThrowsAny<Exception>(() => Location.Create(negativeId, validType));
    }

    

    [Fact]
    public void Create_WhenEmptyType_ThenThrowException()
    {
        var validId = 1;
        var invalidType = string.Empty;

        Assert.ThrowsAny<Exception>(() => Location.Create(validId, invalidType));
    }

    [Fact]
    public void Create_WhenNullType_ThenThrowException()
    {
        var validId = 1;
        string invalidType = null!;

        Assert.ThrowsAny<Exception>(() => Location.Create(validId, invalidType));
    }

    [Fact]
    public void Create_WhenNonnegativeIdAndNonemptyType_ThenSuccess()
    {
        var validId = 1;
        var validType = "village";

        _ = Location.Create(validId, validType);
    }

    [Fact]
    public void Create_WhenNonnegativeIdAndNonemptyType_ThenReturnNotNullLocation()
    {
        var validId = 1;
        var validType = "village";

        var location = Location.Create(validId, validType);

        Assert.NotNull(location);
    }

    [Fact]
    public void Create_WhenNonnegativeIdAndNonemptyType_ThenReturnLocationWithGivenArguments()
    {
        var validId = 1;
        var validType = "village";

        var location = Location.Create(validId, validType);

        Assert.Equal(validId, location.Id);
        Assert.Equal(validType, location.Type);
    }
}
