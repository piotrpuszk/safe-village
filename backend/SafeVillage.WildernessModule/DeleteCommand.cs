using MediatR;

namespace SafeVillage.WildernessModule;

internal record DeleteCommand(int Id) : IRequest;
