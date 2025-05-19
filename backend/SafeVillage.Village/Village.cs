using Ardalis.GuardClauses;

namespace SafeVillage.Village;
internal class Village
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Building> Buildings { get; private set; } = [];

    public Village()
    {
        
    }

    private Village(
        int id,
        string name,
        List<Building> buildings)
    {
        Id = id;
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
        sequence = Guard.Against.Null(sequence);
        var id = Guard.Against.Negative(sequence.GetNext());
        var buildingsDeepCopy = buildings.Select(e => new Building(e)).ToList().AsReadOnly();

        return new(id, name, [.. buildingsDeepCopy]);
    }
}
