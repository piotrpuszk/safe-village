namespace SafeVillage.Village;

internal interface IVillageRepository
{
    Task AddAsync(Village village);
    Task DeleteAsync(int id);
    Task<Village> GetAsync(int villageId, IReadOnlyCollection<Building> buildings);
}
