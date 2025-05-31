using MediatR;

namespace SafeVillage.WaterModule.Contracts;

public record DeleteWaterCommand(int Id) : IRequest;