using MediatR;

namespace SafeVillage.Building.Contracts;
public record GetBuildingByIdIntegrationQuery(int BuildingId) : IRequest<BuildingDto>;
