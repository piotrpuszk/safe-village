using MediatR;
using SafeVillage.World.Contracts;

namespace SafeVillage.Wilderness.Integrations;
internal class RegisterLocationTypesNotificationHandler(IMediator mediator) : INotificationHandler<RegisterLocationTypesNotification>
{
    public async Task Handle(RegisterLocationTypesNotification notification, CancellationToken cancellationToken)
    {
        await mediator.Send(new AddLocationTypeCommand(Constants.LocationType), cancellationToken);
    }
}
