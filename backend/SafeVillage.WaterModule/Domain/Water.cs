using Ardalis.GuardClauses;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.Domain;
internal class Water
{
    public int Id { get; private set; }

    public Water()
    {

    }

    private Water(int id)
    {
        Id = id;
    }

    public static Water Create(ISequence<Water> sequence)
    {
        sequence = Guard.Against.Null(sequence);
        var id = Guard.Against.Negative(sequence.GetNext());

        return new(id);
    }
}
