using SafeVillage.WaterModule.Domain;

namespace SafeVillage.WaterModule.Interfaces;
internal interface IWaterRepository
{
    Task<bool> AddAsync(Water water);
    Task<bool> DeleteAsync(int id);
    Task<Water?> GetAsync(int id);
}
