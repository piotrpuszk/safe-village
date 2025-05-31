using MediatR;

namespace SafeVillage.WaterModule.Contracts;
public record CreateWaterCommand : IRequest<CreateWaterResult>;
