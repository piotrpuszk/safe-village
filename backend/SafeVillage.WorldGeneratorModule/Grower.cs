namespace SafeVillage.WorldGeneratorModule;
internal static class Grower
{
    public static World Grow(World world)
    {
        Console.WriteLine("Growing...");
        World result = new(world);
        var seeds = result.Locations.Where(e => e.GrowSize > 0).ToList();

        while (result.HasFreeLocationSlot())
        {
            foreach (var seed in seeds)
            {
                var freeSlots = result.GetFreeNeighborLocationSlots(seed.Coordinates).Take(seed.GrowSize).ToList();
                foreach (var freeSlot in freeSlots)
                {
                    Location location = new(freeSlot, seed.Type, seed.GrowSize);
                    result.AddLocation(location);
                }
            }

            seeds = [.. result.Locations.Where(e => e.GrowSize > 0)];
        }

        return result;
    }
}
