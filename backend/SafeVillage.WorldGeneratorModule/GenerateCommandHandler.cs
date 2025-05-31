using Mapster;
using MediatR;
using SafeVillage.VillageModule.Contracts;
using SafeVillage.WildernessModule.Contracts;
using SafeVillage.WorldModule.Contracts;
using System.Text.Json;

namespace SafeVillage.WorldGeneratorModule;
internal class GenerateCommandHandler(IMediator mediator) : IRequestHandler<GenerateCommand>
{
    public async Task Handle(GenerateCommand request, CancellationToken cancellationToken)
    {
        List<Location> locations = [];
        List<LocationTemplate> locationTemplates =
            [
                new(LocationType.Water, 0.998f, 8),
                new(LocationType.Wilderness, 0.99f, 1),
                new(LocationType.Village, 0.99f, 0),
            ];

        Generator generator = new(locationTemplates);
        World world = generator.Generate();
        SaveWorldToFile(world);

        var createWorldCommand = request.Adapt<CreateWorldCommand>();

        await mediator.Send(createWorldCommand, cancellationToken);

        foreach (var location in world.Locations)
        {
            switch (location.Type)
            {
                case LocationType.Water:
                    break;
                case LocationType.Wilderness:
                    CreateWildernessCommand createWildernessCommand = new();
                    await mediator.Send(createWildernessCommand, cancellationToken);
                    break;
                case LocationType.Village:
                    CreateVillageCommand createVillageCommand = new("Village");
                    await mediator.Send(createVillageCommand, cancellationToken);
                    break;
                default:
                    break;
            }
        }
    }

    void SaveWorldToFile(World world)
    {
        List<LocationToSave> toSave = [];

        foreach (var coordinates in CoordinatesSequence.GetNext())
        {
            var location = world[coordinates];
            toSave.Add(new(location.Coordinates.X, location.Coordinates.Y, (int)location.Type));
        }

        var serialized = JsonSerializer.Serialize(toSave);
        File.WriteAllText("output.json", serialized);
    }

    private record LocationToSave(int X, int Y, int LocationTypeId);
}
