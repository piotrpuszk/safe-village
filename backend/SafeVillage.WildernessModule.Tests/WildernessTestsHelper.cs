using SafeVillage.WildernessModule.Domain;
using SafeVillage.WildernessModule.Interfaces;

namespace SafeVillage.WildernessModule.Tests;

public class WildernessSequence(int id) : ISequence<Wilderness>
{
    public int GetNext()
    {
        return id;
    }
}
