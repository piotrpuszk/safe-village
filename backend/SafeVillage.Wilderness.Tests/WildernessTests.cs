namespace SafeVillage.Wilderness.Tests;
public class WildernessTests
{
    [Fact]
    public void Create_WhenSequenceIsNull_ThenThrowException()
    {
        ISequence<Wilderness> nullSequence = null!;
        var validInhabitPoints = 1;

        Assert.ThrowsAny<Exception>(() => Wilderness.Create(nullSequence, validInhabitPoints));
    }

    [Fact]
    public void Create_WhenNegativeId_ThenThrowException()
    {
        ISequence<Wilderness> invalidSequence = new WildernessSequence(-1);
        var validInhabitPoints = 1;

        Assert.ThrowsAny<Exception>(() => Wilderness.Create(invalidSequence, validInhabitPoints));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void Create_WhenInhabitPointsAreInvalid_ThenThrowException(int invalidInhabitPoints)
    {
        var validId = 1;
        ISequence<Wilderness> validSequence = new WildernessSequence(validId);

        Assert.ThrowsAny<Exception>(() => Wilderness.Create(validSequence, invalidInhabitPoints));
    }

    [Fact]
    public void Create_WhenValidArguments_ThenSuccess()
    {
        var validId = 1;
        ISequence<Wilderness> validSequence = new WildernessSequence(validId);
        var validInhabitPoints = 1;

        _ = Wilderness.Create(validSequence, validInhabitPoints);
    }

    [Fact]
    public void Create_WhenValidArguments_ThenReturnWildernessWithSameState()
    {
        var validId = 1;
        ISequence<Wilderness> validSequence = new WildernessSequence(validId);
        var validInhabitPoints = 1;

        var wilderness = Wilderness.Create(validSequence, validInhabitPoints);

        Assert.Equal(validId, wilderness.Id);
        Assert.Equal(validInhabitPoints, wilderness.InhabitPoints);
    }

    [Fact]
    public void Create_WhenValidArguments_ThenReturnNotNullWilderness()
    {
        var validId = 1;
        ISequence<Wilderness> validSequence = new WildernessSequence(validId);
        var validInhabitPoints = 1;

        var wilderness = Wilderness.Create(validSequence, validInhabitPoints);

        Assert.NotNull(wilderness);
    }
}
