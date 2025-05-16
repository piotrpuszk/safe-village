using Ardalis.GuardClauses;

namespace SafeVillage.Village;
internal class Village
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Building> Buildings { get; private set; } = [];

    private Village(
        ISequence<Village> sequence,
        string name,
        List<Building> buildings)
    {
        Id = sequence.GetNext();
        Name = name;
        Buildings = buildings;
    }

    public static Village Create(
        ISequence<Village> sequence,
        string name,
        IReadOnlyCollection<Building> buildings)
    {
        name = Guard.Against.NullOrEmpty(name);
        buildings = Guard.Against.Null(buildings);

        return new(sequence, name, [.. buildings]);
    }
}
