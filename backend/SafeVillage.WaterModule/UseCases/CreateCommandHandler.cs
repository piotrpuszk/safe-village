using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WaterModule.Domain;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.UseCases;

internal class CreateCommandHandler(IWaterRepository waterRepository,
    ISequence<Water> sequence) : IRequestHandler<CreateCommand, CreateResult>
{
    public async Task<CreateResult> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var water = Water.Create(sequence);
        Guard.Against.Expression(e => !e, await waterRepository.AddAsync(water), $"failed to add water: {water.Id}");
        return new(water.Id);
    }
}
