using Mapster;
using MediatR;

namespace SafeVillage.Village;

internal class GetQueryHandler(IVillageRepository villageRepository,
    IBuildingRepository buildingRepository) : IRequestHandler<GetQuery, VillageDto>
{
    public async Task<VillageDto> Handle(GetQuery request, CancellationToken cancellationToken)
    {
        var buildings = await buildingRepository.GetVillageBuildingsAsync(request.Id);
        var village = await villageRepository.GetAsync(request.Id, buildings);

        return village.Adapt<VillageDto>();
    }
}
