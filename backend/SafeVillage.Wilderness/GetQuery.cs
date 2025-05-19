using MediatR;

namespace SafeVillage.Wilderness;

internal record GetQuery(int Id) : IRequest<WildernessDto>;
