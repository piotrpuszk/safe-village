namespace SafeVillage.Wilderness;
internal interface IWildernessRepository
{
    Task<bool> AddAsync(Wilderness wilderness);
    Task<bool> DeleteAsync(int id);
    Task<Wilderness?> GetAsync(int id);
}
