using Mapster;
using MediatR;
using SafeVillage.WorldModule.Contracts;

namespace SafeVillage.WorldModule.Integrations;
internal class CreateWorldCommandHandler(IMediator mediator) : IRequestHandler<CreateWorldCommand>
{
    public async Task Handle(CreateWorldCommand request, CancellationToken cancellationToken)
    {
        var command = request.Adapt<UseCases.Create.CreateWorldCommand>();

        await mediator.Send(command, cancellationToken);
    }
}
