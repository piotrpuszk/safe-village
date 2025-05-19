using MediatR;

namespace SafeVillage.Village;
internal record GetQuery(int VillageId) : IRequest<VillageDto>;
