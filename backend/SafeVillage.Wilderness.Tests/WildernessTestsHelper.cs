namespace SafeVillage.Wilderness.Tests;

public class WildernessSequence(int id) : ISequence<Wilderness>
{
    public int GetNext()
    {
        return id;
    }
}
