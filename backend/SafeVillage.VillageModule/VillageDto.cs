namespace SafeVillage.VillageModule;

internal record VillageDto(
    int Id,
    string Name,
    IReadOnlyCollection<BuildingDto> Buildings
    );
