using Ardalis.GuardClauses;

namespace SafeVillage.World;
internal class Area
{
    public Coordinates Coordinates { get; private set; }
    public Location? Location { get; set; }

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

        return new(coordinates);
    }

    public static Area Create(Coordinates coordinates, Location location)
    {
        coordinates = Guard.Against.Null(coordinates);
        location = Guard.Against.Null(location);

        return new(coordinates, location);
    }
}
