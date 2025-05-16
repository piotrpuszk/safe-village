
namespace SafeVillage.Village;
internal interface IBuildingRepository
{
    Task AddAsync(Building building);
    Task DeleteAsync(Building building);
    Task<IReadOnlyCollection<Building>> GetVillageBuildingsAsync(int villageId);
}
