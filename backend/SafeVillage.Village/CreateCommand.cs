using MediatR;

namespace SafeVillage.Village;

internal record CreateCommand(string Name) : IRequest<int>;
