using Mapster;
using MediatR;
using SafeVillage.World.Domain;
using SafeVillage.World.Dtos;

namespace SafeVillage.World.UseCases.Get;
internal class GetWorldQueryHandler(IWorldRepository worldRepository) : IRequestHandler<GetWorldQuery, GetWorldResult>
{
    public async Task<GetWorldResult> Handle(GetWorldQuery request, CancellationToken cancellationToken)
    {
        var world = await worldRepository.GetAsync();

        WorldDto worldDto = world.Adapt<WorldDto>();

        return new(worldDto);
    }
}
