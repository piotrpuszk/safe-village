using Ardalis.GuardClauses;

namespace SafeVillage.World;
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

        return new(worldId, [.. areas]);
    }
}
