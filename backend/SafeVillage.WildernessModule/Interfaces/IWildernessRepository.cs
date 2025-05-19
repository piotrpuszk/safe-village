using SafeVillage.WildernessModule.Domain;

namespace SafeVillage.WildernessModule.Interfaces;
internal interface IWildernessRepository
{
    Task<bool> AddAsync(Wilderness wilderness);
    Task<bool> DeleteAsync(int id);
    Task<Wilderness?> GetAsync(int id);
}
