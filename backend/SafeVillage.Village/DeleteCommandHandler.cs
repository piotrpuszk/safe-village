using Ardalis.GuardClauses;
using MediatR;

namespace SafeVillage.Village;

internal class DeleteCommandHandler(IVillageRepository villageRepository,
    IBuildingRepository buildingRepository,
    IHouseRepository houseRepository) : IRequestHandler<DeleteCommand>
{
    public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Building> buildings = await buildingRepository.GetVillageBuildingsAsync(request.Id);
        var village = Guard.Against.Null(await villageRepository.GetAsync(request.Id, buildings));

        foreach (var building in village.Buildings)
        {
            Guard.Against.Expression(e => !e, await houseRepository.DeleteAsync(building.Id), $"failed to delete building: {building.Id}");
        }

        Guard.Against.Expression(e => !e, await villageRepository.DeleteAsync(village.Id), $"failed to delete village: {village.Id}");
    }
}
