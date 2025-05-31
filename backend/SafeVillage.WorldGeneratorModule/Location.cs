namespace SafeVillage.WorldGeneratorModule;
internal record Location(Coordinates Coordinates, LocationType Type, int GrowSize)
{
    public Location(Coordinates coordinates, LocationTemplate locationTemplate) : this(coordinates, locationTemplate.Type, locationTemplate.GrowSize)
    {
    }

    public Location(Location location)
    {
        Coordinates = location.Coordinates;
        Type = location.Type;
        GrowSize = location.GrowSize;
    }
}
