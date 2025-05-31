using Ardalis.GuardClauses;
using MediatR;
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
        List<Area> areaList = [];
        await mediator.Publish(new RegisterLocationTypesNotification(), cancellationToken);

        for (int row = 0; row < request.Width; ++row)
        {
            for (int column = 0; column < request.Height; ++column)
            {
                Coordinates coordinates = new(row, column);
                Area area = Area.Create(coordinates);
                areaList.Add(area);
            }
        }

        try
        {
            context.BeginTransaction();

            World world = World.Create(1, areaList);
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
