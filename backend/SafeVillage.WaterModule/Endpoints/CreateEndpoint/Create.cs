using FastEndpoints;
using Mapster;
using MediatR;
using SafeVillage.WaterModule.Endpoints.GetEndpoint;
using SafeVillage.WaterModule.UseCases;

namespace SafeVillage.WaterModule.Endpoints.CreateEndpoint;
internal class Create(IMediator mediator) : Endpoint<CreateRequest>
{
    public override void Configure()
    {
        Post($"/api/{Constants.LocationType}/" + "{id}");
    }

    public override async Task HandleAsync(CreateRequest req, CancellationToken ct)
    {
        CreateCommand command = req.Adapt<CreateCommand>();

        var result = await mediator.Send(command, ct);

        await SendCreatedAtAsync<Get>(new { id = result.WaterId }, result.WaterId, cancellation: ct);
    }
}
