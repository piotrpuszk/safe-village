using Ardalis.GuardClauses;
using SafeVillage.WildernessModule.Interfaces;

namespace SafeVillage.WildernessModule.Domain;
internal class Wilderness
{
    public int Id { get; private set; }
    public int InhabitPoints { get; private set; }

    public Wilderness()
    {

    }

    private Wilderness(int id, int inhabitPoints)
    {
        Id = id;
        InhabitPoints = inhabitPoints;
    }

    public static Wilderness Create(ISequence<Wilderness> sequence, int inhabitPoints)
    {
        sequence = Guard.Against.Null(sequence);
        inhabitPoints = Guard.Against.NegativeOrZero(inhabitPoints);
        var id = Guard.Against.Negative(sequence.GetNext());

        return new(id, inhabitPoints);
    }
}
