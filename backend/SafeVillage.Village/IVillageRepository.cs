namespace SafeVillage.Village;

internal interface IVillageRepository
{
    Task<bool> AddAsync(Village village);
    Task<bool> DeleteAsync(int id);
    Task<Village?> GetAsync(int villageId, IReadOnlyCollection<Building> buildings);
}
