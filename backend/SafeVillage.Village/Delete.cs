using FastEndpoints;
using MediatR;

namespace SafeVillage.Village;
internal class Delete(IMediator mediator) : Endpoint<DeleteRequest>
{
    public override void Configure()
    {
        Delete($"/api/{Constants.LocationType}/" + "{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DeleteRequest req, CancellationToken ct)
    {
        DeleteCommand command = new(req.VillageId);

        await mediator.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}
