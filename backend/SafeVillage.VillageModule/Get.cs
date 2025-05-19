using FastEndpoints;
using Mapster;
using MediatR;

namespace SafeVillage.VillageModule;
internal class Get(IMediator mediator) : Endpoint<GetRequest, GetResponse>
{
    public override void Configure()
    {
        Get($"/api/{Constants.LocationType}/" + "{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        GetQuery query = req.Adapt<GetQuery>();

        var result = await mediator.Send(query, ct);

        await SendOkAsync(new GetResponse(result), ct);
    }
}
