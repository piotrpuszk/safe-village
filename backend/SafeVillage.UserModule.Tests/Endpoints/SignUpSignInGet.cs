using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.UserModule.Endpoints;
using System.Net;

namespace SafeVillage.UserModule.Tests.Endpoints;
[Collection("Sequential")]
public class SignUpSignInGet(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidCredentials_ThenSignUpSignInAndGetLoggedUser()
    {
        var username = Guid.NewGuid().ToString().ToUpperInvariant();
        var password = """Pa$$wrd1_Valid_!@%%$Didffucadsf""";

        SignUpRequest signUpRequest = new(username, password);

        var signUpResponse = await app.Client.POSTAsync<SignUp, SignUpRequest>(signUpRequest);
        signUpResponse.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.NoContent, signUpResponse.StatusCode);

        SignInRequest signInRequest = new(username, password);

        var signInResponse = await app.Client.POSTAsync<SignIn, SignInRequest, SignInResponse>(signInRequest);
        signInResponse.Response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, signInResponse.Response.StatusCode);
        Assert.NotNull(signInResponse.Result);
        var token = signInResponse.Result.Token;
        Assert.NotNull(token);
        Assert.NotEmpty(token);

        app.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var getLoggedUserResponse = await app.Client.GETAsync<GetLoggedUser, GetLoggedUserResponse>();
        getLoggedUserResponse.Response.EnsureSuccessStatusCode();
        Assert.Equal(HttpStatusCode.OK, getLoggedUserResponse.Response.StatusCode);
        Assert.NotNull(getLoggedUserResponse.Result);
        var loggedUser = getLoggedUserResponse.Result.User;
        Assert.NotNull(loggedUser);
        Assert.Equal(username, loggedUser.Username);
    }
}
