using MediatR;

namespace SafeVillage.VillageModule.UseCases.Create;

internal record CreateCommand(string Name) : IRequest<int>;
