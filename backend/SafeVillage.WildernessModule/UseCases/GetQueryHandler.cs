using Mapster;
using MediatR;
using SafeVillage.WildernessModule.Dtos;
using SafeVillage.WildernessModule.Interfaces;

namespace SafeVillage.WildernessModule.UseCases;

internal class GetQueryHandler(IWildernessRepository wildernessRepository) : IRequestHandler<GetQuery, WildernessDto>
{
    public async Task<WildernessDto> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var wilderness = await wildernessRepository.GetAsync(request.Id);

        return wilderness.Adapt<WildernessDto>();
    }
}
