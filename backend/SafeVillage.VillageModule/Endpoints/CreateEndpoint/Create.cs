using FastEndpoints;
using Mapster;
using MediatR;
using SafeVillage.VillageModule.Endpoints.GetEndpoint;
using SafeVillage.VillageModule.UseCases.Create;

namespace SafeVillage.VillageModule.Endpoints.CreateEndpoint;

internal class Create(IMediator mediator) : Endpoint<CreateRequest>
{
    public override void Configure()
    {
        Post($"/api/{Constants.LocationType}");
    }

    public override async Task HandleAsync(CreateRequest req, CancellationToken ct)
    {
        CreateCommand command = req.Adapt<CreateCommand>();

        var villageId = await mediator.Send(command, ct);

        await SendCreatedAtAsync<Get>(new { id = villageId }, villageId, cancellation: ct);
    }
}
