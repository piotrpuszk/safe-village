using MediatR;

namespace SafeVillage.VillageModule;
internal record GetQuery(int Id) : IRequest<VillageDto>;
