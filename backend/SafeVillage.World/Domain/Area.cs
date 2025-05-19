using Ardalis.GuardClauses;

namespace SafeVillage.World.Domain;
internal class Area
{
    public Coordinates Coordinates { get; private set; }
    public Location? Location { get; set; }

    public Area(Area area)
    {
        Coordinates = area.Coordinates;
        Location = area.Location is not null ? new Location(area.Location) : null;
    }

    private Area(Coordinates coordinates)
    {
        Coordinates = coordinates;
    }

    private Area(Coordinates coordinates, Location? location) : this(coordinates)
    {
        Location = location;
    }

    public static Area Create(Coordinates coordinates)
    {
        coordinates = Guard.Against.Null(coordinates);

        return new(coordinates with { });
    }

    public static Area Create(Coordinates coordinates, Location location)
    {
        coordinates = Guard.Against.Null(coordinates);
        location = Guard.Against.Null(location);

        return new(coordinates with { }, new(location));
    }
}
