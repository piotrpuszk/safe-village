using Ardalis.GuardClauses;
using MediatR;
using SafeVillage.Building.Contracts;

namespace SafeVillage.Building.Integrations;
internal class GetBuildingByIdIntegrationQueryHandler(IBuildingRepository buildingRepository) : IRequestHandler<GetBuildingByIdIntegrationQuery, BuildingDto>
{
    public async Task<BuildingDto> Handle(GetBuildingByIdIntegrationQuery request, CancellationToken cancellationToken)
    {
        Building building = Guard.Against.Null(await buildingRepository.GetByIdAsync(request.BuildingId));

        return new(building.Id, building.Name, building.IsLevelable, building.IsStorable, building.IsHabitable);
    }
}
