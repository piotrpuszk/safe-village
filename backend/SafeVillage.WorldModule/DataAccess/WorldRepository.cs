using SafeVillage.WorldModule.Domain;
using SafeVillage.WorldModule.Interfaces;

namespace SafeVillage.WorldModule.DataAccess;

internal class WorldRepository(IDbContext context) : IWorldRepository
{
    public async Task<bool> AddAsync(Domain.World world)
    {
        string insertlocationSql = """
            insert into locations(id, type) values(@id, @type)
            """;
        string insertAreaSql = """
            insert into areas(coordinate_x, coordinate_y, location_id) values(@x, @y, @locationId)
            """;
        string insertWorldSql = """
            insert into worlds values(@id)
            """;

        var affected = await context.ExecuteAsync(insertWorldSql, new { id = world.Id });

        if (affected == 0)
        {
            return false;
        }

        foreach (var area in world.Areas)
        {
            if (area.Location is not null)
            {
                affected = await context.ExecuteAsync(insertlocationSql, new { id = area.Location.Id, type = area.Location.Type });

                if (affected == 0)
                {
                    return false;
                }
            }

            affected = await context.ExecuteAsync(insertAreaSql, new { x = area.Coordinates.X, y = area.Coordinates.Y, locationId = area.Location?.Id });

            if (affected == 0)
            {
                return false;
            }
        }

        return true;
    }

    public async Task<bool> AddLocationTypeAsync(string locationType)
    {
        var sql = """
            insert into location_types(name) values(@locationType)
            """;

        return await context.ExecuteAsync(sql, new { locationType }) > 0;
    }

    public async Task<bool> DeleteAsync()
    {
        if (await context.ExecuteAsync("""delete from worlds""") == 0) return false;
        if (await context.ExecuteAsync("""delete from areas""") == 0) return false;
        if (await context.ExecuteAsync("""delete from locations""") == 0) return false;
        if (await context.ExecuteAsync("""delete from location_types""") == 0) return false;

        return true;
    }

    public async Task<Domain.World> GetAsync()
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
            var correspondingLocation = locations.FirstOrDefault(l => l.Id == e.location_id);
            if (correspondingLocation is not null)
            {
                return Area.Create(new(e.coordinate_x, e.coordinate_y), correspondingLocation);
            }
            return Area.Create(new(e.coordinate_x, e.coordinate_y));
        }).ToList()
        .AsReadOnly();


        return Domain.World.Create(worldDb.Id, areas);
    }

    public async Task<IReadOnlyCollection<string>> GetLocationTypesAsync()
    {
        var sql = """
            select name
            from location_types
            """;

        return (await context.QueryAsync<string>(sql)).ToList().AsReadOnly();
    }
}
