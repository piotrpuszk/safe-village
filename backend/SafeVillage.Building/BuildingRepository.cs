namespace SafeVillage.Building;

internal class BuildingRepository(IDbContext<DapperContext> context) : IBuildingRepository
{
    public Task<Building?> GetByIdAsync(int id)
    {
        var sql = """
            select id
                ,name
                ,IsLevelable
                ,IsStorable
                ,IsHabitable
            from buildings
            where id = @id
            """;

        return context.QueryFirstAsync<Building>(sql, new { id });
    }
}
