using Ardalis.GuardClauses;
using MediatR;

namespace SafeVillage.Wilderness;

internal class CreateCommandHandler(IWildernessRepository wildernessRepository,
    ISequence<Wilderness> sequence) : IRequestHandler<CreateCommand, CreateResult>
{
    public async Task<CreateResult> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        var wilderness = Wilderness.Create(sequence, request.InhabitPoints);
        Guard.Against.Expression(e => !e, await wildernessRepository.AddAsync(wilderness), $"failed to add wilderness: {wilderness.Id}");
        return new(wilderness.Id);
    }
}
