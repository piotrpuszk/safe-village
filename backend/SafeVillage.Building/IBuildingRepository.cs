namespace SafeVillage.Building;
internal interface IBuildingRepository
{
    Task<Building?> GetByIdAsync(int id);
}
