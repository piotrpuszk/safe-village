using MediatR;

namespace SafeVillage.World;

internal record DeleteWorldCommand : IRequest;

internal class DeleteWorldCommandHandler(IWorldRepository worldRepository) : IRequestHandler<DeleteWorldCommand>
{
    public Task Handle(DeleteWorldCommand request, CancellationToken cancellationToken)
    {
        return worldRepository.DeleteAsync();
    }
}
