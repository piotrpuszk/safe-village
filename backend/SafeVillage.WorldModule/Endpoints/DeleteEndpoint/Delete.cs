using FastEndpoints;
using MediatR;
using SafeVillage.WorldModule.UseCases.Delete;

namespace SafeVillage.WorldModule.Endpoints.DeleteEndpoint;
internal class Delete(IMediator mediator) : EndpointWithoutRequest
{
    public override void Configure()
    {
        Delete("/api/world");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        DeleteWorldCommand command = new();

        await mediator.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}
