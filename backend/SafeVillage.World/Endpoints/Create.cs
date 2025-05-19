using FastEndpoints;
using MediatR;
using SafeVillage.World.UseCases.Create;
using System.Net;

namespace SafeVillage.World.Endpoints;

internal class Create(IMediator mediator) : Endpoint<CreateRequest>
{
    public override void Configure()
    {
        Post("/api/world");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRequest req, CancellationToken ct)
    {
        CreateWorldCommand command = new(req.Width, req.Height);

        await mediator.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}
