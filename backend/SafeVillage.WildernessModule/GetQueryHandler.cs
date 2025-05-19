using Mapster;
using MediatR;

namespace SafeVillage.WildernessModule;

internal class GetQueryHandler(IWildernessRepository wildernessRepository) : IRequestHandler<GetQuery, WildernessDto>
{
    public async Task<WildernessDto> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var wilderness = await wildernessRepository.GetAsync(request.Id);

        return wilderness.Adapt<WildernessDto>();
    }
}
