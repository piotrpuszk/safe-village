using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.World.Contracts;

namespace SafeVillage.World.Integrations;
internal class AddLocationTypeCommandHandler(IWorldRepository worldRepository) : IRequestHandler<AddLocationTypeCommand>
{
    public async Task Handle(AddLocationTypeCommand request, CancellationToken cancellationToken)
    {
        Guard.Against.Expression(e => !e, await worldRepository.AddLocationTypeAsync(request.LocationType), $"failed to add location type: {request.LocationType}");
    }
}
