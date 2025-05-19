using MediatR;

namespace SafeVillage.WildernessModule.UseCases;

internal record DeleteCommand(int Id) : IRequest;
