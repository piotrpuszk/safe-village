using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.VillageModule.Endpoints.CreateEndpoint;
using SafeVillage.VillageModule.Endpoints.DeleteEndpoint;
using SafeVillage.VillageModule.Endpoints.GetEndpoint;
using System.Net;

namespace SafeVillage.VillageModule.Tests.Endpoints;
[Collection("Sequential")]
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidName_ThenCreateVillage_ThenGetThisVillage_ThenThisDeleteVillage()
    {
        var validName = "my test village";
        var token = await GetToken();
        app.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        var createResponse = await app.Client.POSTAsync<Create, CreateRequest, int>(new CreateRequest(validName));

        Assert.Equal(HttpStatusCode.Created, createResponse.Response.StatusCode);


        var getResponse = await app.Client.GETAsync<Get, GetRequest, GetResponse>(new(createResponse.Result));

        Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);

        var village = getResponse?.Result?.VillageDto;

        Assert.NotNull(village);
        Assert.Equal(validName, village.Name);
        Assert.Equal(createResponse.Result, village.Id);
        Assert.NotNull(village.Buildings);
        Assert.Empty(village.Buildings);

        var deleteResponse = await app.Client.DELETEAsync<Delete, DeleteRequest>(new DeleteRequest(village.Id));

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
