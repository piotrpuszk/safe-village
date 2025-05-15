using Ardalis.GuardClauses;

namespace SafeVillage.Building;
internal class Building
{

    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool IsLevelable { get; private set; }
    public bool IsStorable { get; private set; }
    public bool IsHabitable { get; private set; }

    private Building(int id, string name, bool isLevelable, bool isStorable, bool isHabitable)
    {
        Id = id;
        Name = name;
        IsLevelable = isLevelable;
        IsStorable = isStorable;
        IsHabitable = isHabitable;
    }

    public static Building Create(int id, string name, bool isLevelable, bool isStorable, bool isHabitable)
    {
        id = Guard.Against.Negative(id);
        name = Guard.Against.NullOrEmpty(name);

        return new(id, name, isLevelable, isStorable, isHabitable);
    }
}
