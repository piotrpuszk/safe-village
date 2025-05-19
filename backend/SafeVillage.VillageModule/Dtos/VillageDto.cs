namespace SafeVillage.VillageModule.Dtos;

internal record VillageDto(
    int Id,
    string Name,
    IReadOnlyCollection<BuildingDto> Buildings
    );
