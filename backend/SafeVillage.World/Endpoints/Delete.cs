using FastEndpoints;
using MediatR;
using SafeVillage.World.UseCases.Delete;

namespace SafeVillage.World.Endpoints;
internal class Delete(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("/api/world");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        DeleteWorldCommand command = new();

        await mediator.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}
