using MediatR;

namespace SafeVillage.Village;

internal record DeleteCommand(int Id) : IRequest;
