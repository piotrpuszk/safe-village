using MediatR;

namespace SafeVillage.WorldModule.UseCases.Get;
internal record GetWorldQuery : IRequest<GetWorldResult>;