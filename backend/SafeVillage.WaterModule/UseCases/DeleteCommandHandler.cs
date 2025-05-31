using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WaterModule.Interfaces;

namespace SafeVillage.WaterModule.UseCases;

internal class DeleteCommandHandler(IWaterRepository waterRepository)
    : IRequestHandler<DeleteCommand>
{
    public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Expression(e => !e, await waterRepository.DeleteAsync(request.Id), $"failed to delete water: {request.Id}");
    }
}
