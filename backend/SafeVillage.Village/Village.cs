using Ardalis.GuardClauses;

namespace SafeVillage.Village;
internal class Village
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<Building> Buildings { get; private set; } = [];

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
        int id,
        string name,
        IReadOnlyCollection<Building> buildings)
    {
        id = Guard.Against.Negative(id);
        name = Guard.Against.NullOrEmpty(name);
        buildings = Guard.Against.Null(buildings);

        return new(id, name, [.. buildings]);
    }
}
