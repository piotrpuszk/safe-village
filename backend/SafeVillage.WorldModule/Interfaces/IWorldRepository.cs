using SafeVillage.WorldModule.Domain;

namespace SafeVillage.WorldModule.Interfaces;
internal interface IWorldRepository
{
    Task<bool> AddAsync(World world);
    Task<bool> AddLocationTypeAsync(string locationType);
    Task<bool> DeleteAsync();
    Task<World> GetAsync();
    Task<IReadOnlyCollection<string>> GetLocationTypesAsync();
}
