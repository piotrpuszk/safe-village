using System.Runtime.InteropServices;

namespace SafeVillage.WorldGeneratorModule;
internal static class Seeder
{
    public static World Seed(World world, IReadOnlyList<LocationTemplate> locationTemplates)
    {
        Console.WriteLine("Seeding...");

        World result = new(world);

        foreach (var coordinates in CoordinatesSequence.GetNext())
        {
            var locationTemplate = SelectLocationTemplate(locationTemplates);
            if (locationTemplate is not null)
            {
                Location location = new(coordinates, locationTemplate);
                result.AddLocation(location);
            }
        }

        return result;
    }

    private static LocationTemplate? SelectLocationTemplate(IReadOnlyList<LocationTemplate> locationTemplates)
    {
        var probability = Random.Shared.NextDouble();
        var filtered = locationTemplates.Where(e => probability > e.SeedProbability).ToList();

        if (filtered.Count == 0)
        {
            return null;
        }

        var span = CollectionsMarshal.AsSpan(filtered);
        Random.Shared.Shuffle(span);
        return span.ToArray().First();
    }
}

