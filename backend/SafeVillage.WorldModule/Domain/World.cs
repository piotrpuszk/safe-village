using Ardalis.GuardClauses;

namespace SafeVillage.WorldModule.Domain;
internal class World
{
    public int Id { get; private set; }

    public List<Area> Areas { get; private set; } = [];

    private World(int id, List<Area> areas)
    {
        Id = id;
        Areas = areas;
    }

    public static World Create(int worldId, IReadOnlyCollection<Area> areas)
    {
        worldId = Guard.Against.Negative(worldId);
        areas = Guard.Against.Null(areas);

        var areasDeepCopy = areas.Select(e => new Area(e)).ToList().AsReadOnly();

        return new(worldId, [.. areasDeepCopy]);
    }
}
