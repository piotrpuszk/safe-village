namespace SafeVillage.Village;
internal interface IBuildingRepository
{
    Task<IReadOnlyCollection<Building>> GetVillageBuildingsAsync(int villageId);
}
