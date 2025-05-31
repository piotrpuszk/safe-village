using SafeVillage.WaterModule.Domain;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.DataAccess;

internal class WaterRepository(IDbContext context) : IWaterRepository
{
    public async Task<bool> AddAsync(Water water)
    {
        return await context.ExecuteAsync("""insert into waters(id) values(@Id)""", water) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await context.ExecuteAsync("""delete from waters where id = @Id""", new { id }) > 0;
    }

    public Task<Water?> GetAsync(int id)
    {
        return context.QueryFirstOrDefaultAsync<Water>("""
            select id
            from waters
            where id = @id
            """, new { id });
    }
}
