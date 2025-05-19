using Mapster;
using MediatR;
using SafeVillage.VillageModule.Dtos;
using SafeVillage.VillageModule.Interfaces;

namespace SafeVillage.VillageModule.UseCases.Get;

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
