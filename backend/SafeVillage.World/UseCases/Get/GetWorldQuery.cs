using MediatR;

namespace SafeVillage.World.UseCases.Get;
internal record GetWorldQuery : IRequest<GetWorldResult>;