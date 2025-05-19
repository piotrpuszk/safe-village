using FastEndpoints;
using Mapster;
using MediatR;

namespace SafeVillage.Wilderness;
internal class Create(IMediator mediator) : Endpoint<CreateRequest>
{
    public override void Configure()
    {
        Post($"/api/{Constants.LocationType}/" + "{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreateRequest req, CancellationToken ct)
    {
        CreateCommand command = req.Adapt<CreateCommand>();

        var result = await mediator.Send(command, ct);

        await SendCreatedAtAsync<Get>(new { id = result.WildernessId }, result.WildernessId, cancellation: ct);
    }
}
