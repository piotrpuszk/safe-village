using MediatR;

namespace SafeVillage.World;
internal record GetWorldQuery : IRequest<GetWorldResult>;