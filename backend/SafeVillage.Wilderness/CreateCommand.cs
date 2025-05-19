using MediatR;

namespace SafeVillage.Wilderness;

internal record CreateCommand(int InhabitPoints) : IRequest<CreateResult>;
