using FastEndpoints;
using Mapster;
using MediatR;

namespace SafeVillage.Wilderness;

internal class Get(IMediator mediator) : Endpoint<GetRequest, GetResponse>
{
    public override void Configure()
    {
        Get($"/api/{Constants.LocationType}/" + "{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var result = await mediator.Send(req.Adapt<GetQuery>(), ct);

        await SendOkAsync(new GetResponse(result));
    }
}
