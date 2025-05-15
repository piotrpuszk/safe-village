using Ardalis.GuardClauses;

namespace SafeVillage.World;
internal class Location
{
    public int Id { get; private set; }
    public string Type { get; private set; }
    
    private Location(int id, string type)
    {
        Id = id;
        Type = type;
    }

    public static Location Create(int id, string type)
    {
        id = Guard.Against.Negative(id);
        type = Guard.Against.NullOrEmpty(type);

        return new(id, type);
    }

}
