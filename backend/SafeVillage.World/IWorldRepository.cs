namespace SafeVillage.World;
internal interface IWorldRepository
{
    Task<World> GetAsync();
}
