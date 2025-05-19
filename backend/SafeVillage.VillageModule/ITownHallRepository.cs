namespace SafeVillage.VillageModule;

internal interface ITownHallRepository
{
    Task<bool> AddAsync(TownHall townHall);
    Task<bool> DeleteAsync(int id);
    Task<TownHall?> GetAsync(int id);
}
