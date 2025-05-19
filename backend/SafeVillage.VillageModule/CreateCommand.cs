using MediatR;

namespace SafeVillage.VillageModule;

internal record CreateCommand(string Name) : IRequest<int>;
