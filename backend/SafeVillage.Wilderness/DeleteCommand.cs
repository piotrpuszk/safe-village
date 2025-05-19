using MediatR;

namespace SafeVillage.Wilderness;

internal record DeleteCommand(int Id) : IRequest;
