using MediatR;

namespace SafeVillage.WaterModule.UseCases;

internal record CreateCommand(int InhabitPoints) : IRequest<CreateResult>;
