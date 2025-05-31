namespace SafeVillage.WorldGeneratorModule;
internal static class MoveVector
{
    public static readonly Coordinates MoveTopLeft = new(-1, 1);
    public static readonly Coordinates MoveTop = new(0, 1);
    public static readonly Coordinates MoveTopRight = new(1, 1);
    public static readonly Coordinates MoveRight = new(1, 0);
    public static readonly Coordinates MoveBotRight = new(1, -1);
    public static readonly Coordinates MoveBot = new(0, -1);
    public static readonly Coordinates MoveBotLeft = new(-1, -1);
    public static readonly Coordinates MoveLeft = new(-1, 0);

    public static IEnumerable<Coordinates> MoveVectors =
        [
            MoveTopLeft,
            MoveTop,
            MoveTopRight,
            MoveRight,
            MoveBotRight,
            MoveBot,
            MoveBotLeft,
            MoveLeft,
        ];
}
