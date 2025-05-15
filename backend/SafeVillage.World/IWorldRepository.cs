namespace SafeVillage.World;
internal interface IWorldRepository
{
    Task AddAsync(World world);
    Task AddLocationTypeAsync(string locationType);
    Task DeleteAsync();
    Task<World> GetAsync();
    Task<IReadOnlyCollection<string>> GetLocationTypesAsync();
}
