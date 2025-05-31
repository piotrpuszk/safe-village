using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WaterModule.Contracts;
using SafeVillage.WaterModule.Domain;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.Integrations;
internal class CreateWaterCommandHandler(
    IWaterRepository waterRepository,
    ISequence<Water> waterSequence) 
    : IRequestHandler<CreateWaterCommand, CreateWaterResult>
{
    public async Task<CreateWaterResult> Handle(CreateWaterCommand request, CancellationToken cancellationToken)
    {
        var water = Water.Create(waterSequence);
        Guard.Against.Expression(e => !e, await waterRepository.AddAsync(water), $"failed to add water: {water.Id}");
        return new(water.Id);
    }
}
