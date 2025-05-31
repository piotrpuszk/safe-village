using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WaterModule.Contracts;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.Integrations;
internal class DeleteWaterCommandHandler(IWaterRepository waterRepository) 
    : IRequestHandler<DeleteWaterCommand>
{
    public async Task Handle(DeleteWaterCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Expression(e => !e, await waterRepository.DeleteAsync(request.Id), $"failed to delete water: {request.Id}");
    }
}
