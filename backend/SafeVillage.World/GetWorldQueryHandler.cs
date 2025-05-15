using Mapster;
using MediatR;

namespace SafeVillage.World;
internal class GetWorldQueryHandler(IWorldRepository worldRepository) : IRequestHandler<GetWorldQuery, GetWorldResult>
{
    public async Task<GetWorldResult> Handle(GetWorldQuery request, CancellationToken cancellationToken)
    {
        World world = await worldRepository.GetAsync();

        WorldDto worldDto = world.Adapt<WorldDto>();

        return new(worldDto);
    }
}
