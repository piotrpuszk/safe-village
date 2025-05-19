namespace SafeVillage.VillageModule;
internal interface IBuildingRepository
{
    Task<IReadOnlyCollection<Building>> GetVillageBuildingsAsync(int villageId);
}
