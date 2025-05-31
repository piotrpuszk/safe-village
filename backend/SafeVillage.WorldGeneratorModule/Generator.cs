namespace SafeVillage.WorldGeneratorModule;
internal class Generator(IReadOnlyList<LocationTemplate> locationTemplates)
{
    public World Generate()
    {
        World world = new([]);
        world = Seeder.Seed(world, locationTemplates);
        world = Grower.Grow(world);
        return world;
    }
}
