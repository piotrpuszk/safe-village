using FastEndpoints;
using Mapster;
using MediatR;

namespace SafeVillage.WorldGeneratorModule.Endpoints;
internal class Generate(IMediator mediator) : Endpoint<GenerateRequest>
{
    public override void Configure()
    {
        Post("/api/world-generator/generate");
    }

    public override async Task HandleAsync(GenerateRequest req, CancellationToken ct)
    {
        GenerateCommand command = req.Adapt<GenerateCommand>();

        await mediator.Send(command, ct);

        await SendCreatedAtAsync("/api/world", null, null);
    }
}
