using SafeVillage.Village.Exceptions;

namespace SafeVillage.Village;

internal class BuildingRepository(IDbContext context) : IBuildingRepository
{
    public async Task AddAsync(Building building)
    {
        var sql = """
            insert into buildings(id, name, splendor_points) values (@Id, @Name, @SplendorPoints);
            """;

        await context.ExecuteAsync(sql, building);

        Task task = building switch
        {
            House house => AddHouseAsync(house),
            TownHall townHall => AddTownHallAsync(townHall),
            _ => throw new MissingAddBuildingMethodException(building.GetType().Name),
        };

        await task;
    }

    public Task DeleteAsync(Building building)
    {
        var sql = """
            delete from houses where id = @Id;
            delete from town_halls where id = @Id;
            delete from buildings where id = @Id;
            """;

        return context.ExecuteAsync(sql, building);
    }

    public async Task<IReadOnlyCollection<Building>> GetVillageBuildingsAsync(int villageId)
    {
        var sql = $"""
            select b.id
                ,number_of_inhabitants numberOfInhabitants
                ,level
                ,name
            from buildings b
                join villages_buildings vb on vb.building_id = b.id
                left join houses h on h.id = b.id
                left join town_halls th on th.id = b.id
            where vb.village_id = @villageId
            """;

        var buildings = (await context.QueryAsync<(int id, int numberOfInhabitants, int level, string name)>(sql, new { villageId })).ToList().AsReadOnly();

        List<Building> result = [];

        foreach (var building in buildings)
        {
            Building toAdd = building.name switch
            {
                House.Name => House.Create(new DummySequence<Building>(building.id), building.numberOfInhabitants),
                TownHall.Name => TownHall.Create(new DummySequence<Building>(building.id), building.level),
                _ => throw new MissingCreateBuildingMethodException(building.name),
            };

            result.Add(toAdd);
        }

        return result;
    }

    private Task AddHouseAsync(House house)
    {
        var sql = """
            insert into houses(id, number_of_inhabitants) values (@Id, @NumberOfInhabitants);
            """;

        return context.ExecuteAsync(sql, house);
    }

    private Task AddTownHallAsync(TownHall townHall)
    {
        var sql = """
            insert into town_halls(id, level) values (@Id, @Level)
            """;

        return context.ExecuteAsync(sql, townHall);
    }
}
