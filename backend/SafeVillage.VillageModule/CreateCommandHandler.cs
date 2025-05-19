using Ardalis.GuardClauses;
using MediatR;

namespace SafeVillage.VillageModule;

internal class CreateCommandHandler(IVillageRepository villageRepository,
    ISequence<Village> villageSequence) : IRequestHandler<CreateCommand, int>
{
    public async Task<int> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var village = Village.Create(villageSequence, request.Name, []);

        Guard.Against.Expression(e => !e, await villageRepository.AddAsync(village), $"failed to add village: {village.Id}");

        return village.Id;
    }
}
