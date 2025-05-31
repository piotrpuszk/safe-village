using Mapster;
using MediatR;
using SafeVillage.WorldModule.Contracts;

namespace SafeVillage.WorldModule.Integrations;

internal class DeleteWorldCommandHandler(IMediator mediator) : IRequestHandler<DeleteWorldCommand>
{
    public async Task Handle(DeleteWorldCommand request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UseCases.Delete.DeleteWorldCommand>();

        await mediator.Send(command, cancellationToken);
    }
}
