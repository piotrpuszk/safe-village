using MediatR;

namespace SafeVillage.WildernessModule;

internal record CreateCommand(int InhabitPoints) : IRequest<CreateResult>;
