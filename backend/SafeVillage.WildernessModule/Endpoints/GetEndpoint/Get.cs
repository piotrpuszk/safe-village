using FastEndpoints;
using Mapster;
using MediatR;
using SafeVillage.WildernessModule.UseCases;

namespace SafeVillage.WildernessModule.Endpoints.GetEndpoint;

internal class Get(IMediator mediator) : Endpoint<GetRequest, GetResponse>
{
    public override void Configure()
    {
        Get($"/api/{Constants.LocationType}/" + "{id}");
    }

    public override async Task HandleAsync(GetRequest req, CancellationToken ct)
    {
        var result = await mediator.Send(req.Adapt<GetQuery>(), ct);

        await SendOkAsync(new GetResponse(result));
    }
}
