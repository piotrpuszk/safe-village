using MediatR;

namespace SafeVillage.WaterModule.UseCases;

internal record DeleteCommand(int Id) : IRequest;
