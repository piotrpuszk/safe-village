using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.WildernessModule.Endpoints.CreateEndpoint;
using SafeVillage.WildernessModule.Endpoints.DeleteEndpoint;
using SafeVillage.WildernessModule.Endpoints.GetEndpoint;
using System.Net;

namespace SafeVillage.WildernessModule.Tests.Endpoints;
[Collection("Sequential")]
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidArguments_ThenCreateWilderness_ThenGetThisWilderness_ThenDeleteThisWilderness()
    {
        var validInhabitPoints = 20;
        var token = await GetToken();
        app.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var createResponse = await app.Client.POSTAsync<Create, CreateRequest, int>(new(validInhabitPoints));

        Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);
        Assert.True(createResponse.Result >= 0);

        var getResponse = await app.Client.GETAsync<Get, GetRequest, GetResponse>(new(createResponse.Result));

        Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);
        var wilderness = getResponse.Result.Wilderness;
        Assert.Equal(createResponse.Result, wilderness.Id);
        Assert.Equal(validInhabitPoints, wilderness.InhabitPoints);

        var deleteResponse = await app.Client.DELETEAsync<Delete, DeleteRequest>(new(wilderness.Id));

        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }

    private async Task<string> GetToken()
    {
        var baseAddress = app.Client.BaseAddress;

        var username = Guid.NewGuid().ToString();
        var password = Guid.NewGuid().ToString();

        var signUpRequest = new { Username = username, Password = password };
        var signUpResponse = await app.Client.POSTAsync<object, object>("/api/users/sign-up", signUpRequest);
        signUpResponse.Response.EnsureSuccessStatusCode();

        var signInRequest = new { username, password };
        var signInResponse = await app.Client.POSTAsync<object, SignInResponse>("/api/users/sign-in", signInRequest);
        signInResponse.Response.EnsureSuccessStatusCode();

        string token = signInResponse.Result.Token;

        return token;
    }

    private class SignInResponse { public string Token { get; set; } = string.Empty; }
}
