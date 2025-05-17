using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.Village.Contracts;

namespace SafeVillage.Village.Integrations;
internal class CreateVillageCommandHandler(IVillageRepository villageRepository,
    IHouseRepository houseRepository,
    ISequence<Building> buildingSequence,
    ISequence<Village> villageSequence) : IRequestHandler<CreateVillageCommand, CreateVillageResult>
{
    public async Task<CreateVillageResult> Handle(CreateVillageCommand request, CancellationToken cancellationToken)
    {
        House house = House.Create(buildingSequence, 5);
        Guard.Against.Expression(e => !e, await houseRepository.AddAsync(house), $"house: {house.Id} cannot be added");

        var test = await houseRepository.GetAsync(house.Id);

        var village = Village.Create(villageSequence, request.Name, [house]);
        Guard.Against.Expression(e => !e, await villageRepository.AddAsync(village), $"village: {village.Id} cannot be added");

        return new(village.Id);
    }
}
