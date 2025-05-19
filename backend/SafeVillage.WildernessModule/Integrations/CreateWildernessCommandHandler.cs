using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WildernessModule.Contracts;
using SafeVillage.WildernessModule.Domain;
using SafeVillage.WildernessModule.Interfaces;

namespace SafeVillage.WildernessModule.Integrations;
internal class CreateWildernessCommandHandler(
    IWildernessRepository wildernessRepository,
    ISequence<Wilderness> wildernessSequence) 
    : IRequestHandler<CreateWildernessCommand, CreateWildernessResult>
{
    public async Task<CreateWildernessResult> Handle(CreateWildernessCommand request, CancellationToken cancellationToken)
    {
        var inhabitPoints = Random.Shared.Next(10, 100);
        var wilderness = Wilderness.Create(wildernessSequence, inhabitPoints);
        Guard.Against.Expression(e => !e, await wildernessRepository.AddAsync(wilderness), $"failed to add wilderness: {wilderness.Id}");
        return new(wilderness.Id);
    }
}
