using MediatR;
using SafeVillage.Village.Contracts;

namespace SafeVillage.Village.Integrations;
internal class CreateVillageCommandHandler(IVillageRepository villageRepository,
    IBuildingRepository buildingRepository,
    ISequence<Building> buildingSequence,
    ISequence<Village> villageSequence) : IRequestHandler<CreateVillageCommand, CreateVillageResult>
{
    public async Task<CreateVillageResult> Handle(CreateVillageCommand request, CancellationToken cancellationToken)
    {
        Building house = House.Create(buildingSequence, 5);
        Building townHall = TownHall.Create(buildingSequence);

        var village = Village.Create(villageSequence, request.Name, [house, townHall]);

        await villageRepository.AddAsync(village);

        foreach (var building in village.Buildings)
        {
            await buildingRepository.AddAsync(building);
        }

        return new(village.Id);
    }
}
