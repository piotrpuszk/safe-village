using FastEndpoints;
using Mapster;
using MediatR;

namespace SafeVillage.UserModule.Endpoints;
internal class SignUp(IMediator mediator) : Endpoint<SignUpRequest>
{
    public override void Configure()
    {
        Post("/api/users/sign-up");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignUpRequest req, CancellationToken ct)
    {
        var command = req.Adapt<SignUpCommand>();

        await mediator.Send(command, ct);

        await SendNoContentAsync(ct);
    }
}
