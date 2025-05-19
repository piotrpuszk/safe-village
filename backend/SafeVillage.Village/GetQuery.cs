using MediatR;

namespace SafeVillage.Village;
internal record GetQuery(int Id) : IRequest<VillageDto>;
