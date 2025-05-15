using MediatR;
using SafeVillage.World.Contracts;

namespace SafeVillage.World.Integrations;
internal class AddLocationTypeCommandHandler(IWorldRepository worldRepository) : IRequestHandler<AddLocationTypeCommand>
{
    public async Task Handle(AddLocationTypeCommand request, CancellationToken cancellationToken)
    {
        await worldRepository.AddLocationTypeAsync(request.LocationType);
    }
}
