using MediatR;
using SafeVillage.Village.Contracts;

namespace SafeVillage.Village.Integrations;
internal class DeleteVillageCommandHandler(IVillageRepository villageRepository,
    IBuildingRepository buildingRepository) : IRequestHandler<DeleteVillageCommand>
{
    public async Task Handle(DeleteVillageCommand request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Building> buildings = await buildingRepository.GetVillageBuildingsAsync(request.VillageId);
        var village = await villageRepository.GetAsync(request.VillageId, buildings);

        foreach (var building in village.Buildings)
        {
            await buildingRepository.DeleteAsync(building);
        }

        await villageRepository.DeleteAsync(village.Id);
    }
}
