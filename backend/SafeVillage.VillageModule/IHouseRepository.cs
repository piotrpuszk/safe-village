namespace SafeVillage.VillageModule;
internal interface IHouseRepository
{
    Task<bool> AddAsync(House house);
    Task<bool> DeleteAsync(int id);
    Task<House?> GetAsync(int id);
}
