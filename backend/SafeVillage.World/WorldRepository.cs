namespace SafeVillage.World;

internal class WorldRepository(IDbContext<DapperContext> context) : IWorldRepository
{
    public async Task<World> GetAsync()
    {
        var sql = """
            select id
            from worlds
            """;

        var worldDb = await context.QuerySingleAsync<WorldDb>(sql);

        var locationsSql = """
            select id
                ,type
            from locations
            """;

        var locations = (await context.QueryAsync<Location>(locationsSql)).ToList();

        var areasSql = """
            select coordinate_x
                ,coordinate_y
                ,location_id
            from areas
            """;

        var areasDb = await context.QueryAsync<dynamic>(areasSql);
        var areas = areasDb.Select(e => 
        {
            var correspondingLocation = locations.First(l => l.Id == e.location_id);
            return Area.Create(new(e.coordinate_x, e.coordinate_y), correspondingLocation);
        }).ToList()
        .AsReadOnly();


        return World.Create(worldDb.Id, areas);
    }
}
