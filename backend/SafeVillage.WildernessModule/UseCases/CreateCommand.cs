using MediatR;

namespace SafeVillage.WildernessModule.UseCases;

internal record CreateCommand(int InhabitPoints) : IRequest<CreateResult>;
