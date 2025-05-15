namespace SafeVillage.Building.Contracts;

public record BuildingDto(int Id, string Name, bool IsLevelable, bool IsStorable, bool IsHabitable);