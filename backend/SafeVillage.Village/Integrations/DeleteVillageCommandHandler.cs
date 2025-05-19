using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.Village.Contracts;

namespace SafeVillage.Village.Integrations;
internal class DeleteVillageCommandHandler(IVillageRepository villageRepository,
    IBuildingRepository buildingRepository,
    IHouseRepository houseRepository) : IRequestHandler<DeleteVillageCommand>
{
    public async Task Handle(DeleteVillageCommand request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Building> buildings = await buildingRepository.GetVillageBuildingsAsync(request.VillageId);
        var village = Guard.Against.Null(await villageRepository.GetAsync(request.VillageId, buildings));

        foreach (var building in village.Buildings)
        {
            Guard.Against.Expression(e => !e, await houseRepository.DeleteAsync(building.Id), $"failed to delete building: {building.Id}");
        }

        Guard.Against.Expression(e => !e, await villageRepository.DeleteAsync(village.Id), $"failed to delete village: {village.Id}");
    }
}
