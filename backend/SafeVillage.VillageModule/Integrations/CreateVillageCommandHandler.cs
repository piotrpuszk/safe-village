using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.VillageModule.Contracts;

namespace SafeVillage.VillageModule.Integrations;
internal class CreateVillageCommandHandler(IVillageRepository villageRepository,
    IHouseRepository houseRepository,
    ITownHallRepository townHallRepository,
    ISequence<Building> buildingSequence,
    ISequence<Village> villageSequence) : IRequestHandler<CreateVillageCommand, CreateVillageResult>
{
    public async Task<CreateVillageResult> Handle(CreateVillageCommand request, CancellationToken cancellationToken)
    {
        House house = House.Create(buildingSequence, 5);
        Guard.Against.Expression(e => !e, await houseRepository.AddAsync(house), $"house: {house.Id} cannot be added");

        TownHall townHall = TownHall.Create(buildingSequence);
        Guard.Against.Expression(e => !e, await townHallRepository.AddAsync(townHall), $"town hall: {townHall.Id} cannot be added");

        var village = Village.Create(villageSequence, request.Name, [house, townHall]);
        Guard.Against.Expression(e => !e, await villageRepository.AddAsync(village), $"village: {village.Id} cannot be added");

        return new(village.Id);
    }
}
