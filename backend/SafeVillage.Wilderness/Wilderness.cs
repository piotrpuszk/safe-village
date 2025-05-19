using Ardalis.GuardClauses;

namespace SafeVillage.Wilderness;
internal class Wilderness
{
    public int Id { get; private set; }
    public int InhabitPoints { get; private set; }

    public Wilderness()
    {

    }

    private Wilderness(ISequence<Wilderness> sequence, int inhabitPoints)
    {
        Id = sequence.GetNext();
        InhabitPoints = inhabitPoints;
    }

    public static Wilderness Create(ISequence<Wilderness> sequence, int inhabitPoints)
    {
        sequence = Guard.Against.Null(sequence);
        inhabitPoints = Guard.Against.NegativeOrZero(inhabitPoints);

        return new(sequence, inhabitPoints);
    }
}
