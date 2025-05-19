using MediatR;
using SafeVillage.VillageModule.Contracts;
using SafeVillage.VillageModule.UseCases.Delete;

namespace SafeVillage.VillageModule.Integrations;
internal class DeleteVillageCommandHandler(IMediator mediator) : IRequestHandler<DeleteVillageCommand>
{
    public async Task Handle(DeleteVillageCommand request, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteCommand(request.VillageId), cancellationToken);
    }
}
