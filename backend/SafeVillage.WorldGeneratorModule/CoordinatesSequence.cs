namespace SafeVillage.WorldGeneratorModule;
internal static class CoordinatesSequence
{
    public static IEnumerable<Coordinates> GetNext()
    {
        for (int x = 0; x < Settings.Width; x++)
        {
            for (int y = 0; y < Settings.Height; y++)
            {
                yield return new(x, y);
            }
        }
    }
}