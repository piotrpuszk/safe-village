using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.VillageModule.Contracts;
using SafeVillage.WildernessModule.Contracts;
using SafeVillage.WorldModule.Contracts;
using SafeVillage.WorldModule.Domain;
using SafeVillage.WorldModule.Interfaces;

namespace SafeVillage.WorldModule.UseCases.Create;

internal class CreateWorldCommandHandler(
    IMediator mediator,
    IDbContext context,
    IWorldRepository worldRepository) : IRequestHandler<CreateWorldCommand>
{
    public async Task Handle(CreateWorldCommand request, CancellationToken cancellationToken)
    {
        var (width, height) = request;

        List<Area> areaList = [];
        Random random = Random.Shared;
        await mediator.Publish(new RegisterLocationTypesNotification());
        string[] locationTypes = [.. await worldRepository.GetLocationTypesAsync()];
        int locationId = 0;

        for (int row = 0; row < width; ++row)
        {
            for (int column = 0; column < height; ++column)
            {
                Coordinates coordinates = new(row, column);
                if (random.NextDouble() >= 0.25)
                {
                    var locationType = locationTypes[random.Next(locationTypes.Length)];
                    if (locationType == "village")
                    {
                        var createVillageResult = await mediator.Send(new CreateVillageCommand("Test village"), cancellationToken);
                        locationId = createVillageResult.VillageId;
                    }
                    else if (locationType == "wilderness")
                    {
                        var createWildernessResult = await mediator.Send(new CreateWildernessCommand(), cancellationToken);
                        locationId = createWildernessResult.WildernessId;
                    }
                    else
                    {
                        throw new Exception($"location missing: {locationType}");
                    }
                    Location location = Location.Create(locationId, locationType);
                    Area area = Area.Create(coordinates, location);
                    areaList.Add(area);
                }
                else
                {
                    Area area = Area.Create(coordinates);
                    areaList.Add(area);
                }
            }
        }

        try
        {
            context.BeginTransaction();

            Domain.World world = Domain.World.Create(1, areaList);
            Guard.Against.Expression(e => !e, await worldRepository.AddAsync(world), "failed to add a world");

            context.Commit();
        }
        catch
        {
            context.Rollback();
            throw;
        }
    }
}
