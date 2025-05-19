using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WildernessModule.Interfaces;

namespace SafeVillage.WildernessModule.UseCases;

internal class DeleteCommandHandler(IWildernessRepository wildernessRepository)
    : IRequestHandler<DeleteCommand>
{
    public async Task Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Expression(e => !e, await wildernessRepository.DeleteAsync(request.Id), $"failed to delete wilderness: {request.Id}");
    }
}
