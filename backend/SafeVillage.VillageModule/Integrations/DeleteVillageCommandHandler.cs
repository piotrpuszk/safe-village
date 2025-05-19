using MediatR;
using SafeVillage.VillageModule.Contracts;

namespace SafeVillage.VillageModule.Integrations;
internal class DeleteVillageCommandHandler(IMediator mediator) : IRequestHandler<DeleteVillageCommand>
{
    public async Task Handle(DeleteVillageCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteCommand(request.VillageId), cancellationToken);
    }
}
