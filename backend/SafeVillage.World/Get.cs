using FastEndpoints;
using MediatR;
using System.Net;

namespace SafeVillage.World;
internal class Get(IMediator mediator) : EndpointWithoutRequest<WorldDto>
{
    public override void Configure()
    {
        Get("/api/world");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        GetWorldQuery query = new();

        GetWorldResult queryResult = await mediator.Send(query, ct);

        var worldDto = queryResult.World;

        await SendOkAsync(worldDto);
    }
}
