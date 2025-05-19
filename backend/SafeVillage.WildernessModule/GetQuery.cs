using MediatR;

namespace SafeVillage.WildernessModule;

internal record GetQuery(int Id) : IRequest<WildernessDto>;
