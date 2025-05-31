using FastEndpoints;
using Mapster;
using MediatR;
using SafeVillage.WaterModule.UseCases;

namespace SafeVillage.WaterModule.Endpoints.DeleteEndpoint;

internal class Delete(IMediator mediator) : Endpoint<DeleteRequest>
{
    public override void Configure()
    {
        Delete($"/api/{Constants.LocationType}/" + "{id}");
    }

    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        await mediator.Send(req.Adapt<DeleteCommand>(), ct);

        await SendNoContentAsync();
    }
}
