using MediatR;
using SafeVillage.VillageModule.Dtos;

namespace SafeVillage.VillageModule.UseCases.Get;
internal record GetQuery(int Id) : IRequest<VillageDto>;
