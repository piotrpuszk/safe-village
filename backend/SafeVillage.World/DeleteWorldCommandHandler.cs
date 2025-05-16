using MediatR;
using SafeVillage.Village.Contracts;

namespace SafeVillage.World;

internal class DeleteWorldCommandHandler(IMediator mediator,
    IWorldRepository worldRepository) : IRequestHandler<DeleteWorldCommand>
{
    public async Task Handle(DeleteWorldCommand request, CancellationToken cancellationToken)
    {
        var world = await worldRepository.GetAsync();

        foreach (var location in world.Areas.Select(e => e.Location))
        {
            if (location?.Type == "village")
            {
                await mediator.Send(new DeleteVillageCommand(location.Id), cancellationToken);
            }
        }

        await worldRepository.DeleteAsync();
    }
}
