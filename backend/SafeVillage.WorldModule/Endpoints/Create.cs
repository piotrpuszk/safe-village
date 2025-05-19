using FastEndpoints;
using MediatR;
using SafeVillage.WorldModule.UseCases.Create;
using System.Net;

namespace SafeVillage.WorldModule.Endpoints;

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
