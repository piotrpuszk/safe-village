using Ardalis.GuardClauses;

namespace SafeVillage.Village;

internal class Building
{
    public int Id { get; private set; }
    public int BuildingId { get; private set; }
    
    private Building(int id, int buildingId)
    {
        Id = id;
        BuildingId = buildingId;
    }

    public static Building Create(int id, int buildingId)
    {
        id = Guard.Against.Negative(id);
        buildingId = Guard.Against.Negative(buildingId);

        return new(id, buildingId);
    }
}