namespace SafeVillage.WorldGeneratorModule;

internal class World
{
    private readonly List<Location> _locations;
    private readonly Location[,] _map = new Location[Settings.Width, Settings.Height];
    private readonly HashSet<Coordinates> _freeLocationSlots = [];

    public IReadOnlyList<Location> Locations => _locations.AsReadOnly();

    public World(List<Location> locations)
    {
        _locations = locations;
        foreach (var item in CoordinatesSequence.GetNext())
        {
            _freeLocationSlots.Add(item);
        }
    }

    public World(World world)
    {
        _locations = world._locations;
        _map = world._map;
        _freeLocationSlots = world._freeLocationSlots;
    }

    public bool IsFreeSlot(Coordinates coordinates)
    {
        return _map[coordinates.X, coordinates.Y] is null;
    }

    public void AddLocation(Location location)
    {
        if (!IsFreeSlot(location.Coordinates))
        {
            throw new InvalidOperationException($"Tried to override location slot at {location.Coordinates}");
        }

        _map[location.Coordinates.X, location.Coordinates.Y] = location;
        _locations.Add(location);
        _freeLocationSlots.Remove(location.Coordinates);
    }

    public bool HasFreeLocationSlot()
    {
        return _freeLocationSlots.Any();
    }

    public bool IsValidCoordinates(Coordinates coordinates)
    {
        return coordinates.X >= 0 && coordinates.X < Settings.Width && coordinates.Y >= 0 && coordinates.Y < Settings.Height;
    }

    public IEnumerable<Coordinates> GetFreeNeighborLocationSlots(Coordinates coordinates)
    {
        List<Coordinates> result = [];

        foreach (var moveVector in MoveVector.MoveVectors)
        {
            Coordinates neighbor = new(coordinates.X + moveVector.X, coordinates.Y + moveVector.Y);

            if (IsValidCoordinates(neighbor) && IsFreeSlot(neighbor))
            {
                result.Add(neighbor);
            }
        }

        return result;
    }

    public Location this[Coordinates coordinates]
    {
        get => _map[coordinates.X, coordinates.Y];
    }
}