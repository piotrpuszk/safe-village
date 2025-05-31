using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.WaterModule.Endpoints.CreateEndpoint;
using SafeVillage.WaterModule.Endpoints.DeleteEndpoint;
using SafeVillage.WaterModule.Endpoints.GetEndpoint;
using System.Net;

namespace SafeVillage.WaterModule.Tests.Endpoints;
[Collection("Sequential")]
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidArguments_ThenCreateWater_ThenGetThisWater_ThenDeleteThisWater()
    {
        var token = await GetToken();
        app.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var createResponse = await app.Client.POSTAsync<Create, CreateRequest, int>(new());

        Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);
        Assert.True(createResponse.Result >= 0);

        var getResponse = await app.Client.GETAsync<Get, GetRequest, GetResponse>(new(createResponse.Result));

        Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);
        var water = getResponse.Result.Water;
        Assert.Equal(createResponse.Result, water.Id);

        var deleteResponse = await app.Client.DELETEAsync<Delete, DeleteRequest>(new(water.Id));

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
