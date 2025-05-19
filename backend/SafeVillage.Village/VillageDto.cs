namespace SafeVillage.Village;

internal record VillageDto(
    int Id,
    string Name,
    IReadOnlyCollection<BuildingDto> Buildings
    );
