using FastEndpoints;
using Mapster;
using MediatR;

namespace SafeVillage.UserModule.Endpoints;

internal class SignIn(IMediator mediator) : Endpoint<SignInRequest, SignInResponse>
{
    public override void Configure()
    {
        Post("/api/users/sign-in");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignInRequest req, CancellationToken ct)
    {
        var command = req.Adapt<SignInCommand>();

        var response = await mediator.Send(command, ct);

        await SendOkAsync(response.Adapt<SignInResponse>(), ct);
    }
}
