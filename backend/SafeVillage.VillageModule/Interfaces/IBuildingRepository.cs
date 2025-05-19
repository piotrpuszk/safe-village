using SafeVillage.VillageModule.Domain;

namespace SafeVillage.VillageModule.Interfaces;
internal interface IBuildingRepository
{
    Task<IReadOnlyCollection<Building>> GetVillageBuildingsAsync(int villageId);
}
