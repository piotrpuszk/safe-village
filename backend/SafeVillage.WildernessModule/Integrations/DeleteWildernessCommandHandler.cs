using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.WildernessModule.Contracts;

namespace SafeVillage.WildernessModule.Integrations;
internal class DeleteWildernessCommandHandler(IWildernessRepository wildernessRepository) 
    : IRequestHandler<DeleteWildernessCommand>
{
    public async Task Handle(DeleteWildernessCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Expression(e => !e, await wildernessRepository.DeleteAsync(request.Id), $"failed to delete wilderness: {request.Id}");
    }
}
