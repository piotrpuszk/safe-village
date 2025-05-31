using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.WorldGeneratorModule.Endpoints;
using SafeVillage.WorldModule.Dtos;
using SafeVillage.WorldModule.Endpoints.DeleteEndpoint;
using SafeVillage.WorldModule.Endpoints.GetEndpoint;
using System.Net;

namespace SafeVillage.WorldGeneratorModule.Tests.Endpoints;
[Collection("Sequential")]
public class GenerateTests(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidRequest_ThenGenerateSuccessfully()
    {
        int width = 100;
        int height = 100;

        var token = await GetToken();

        app.Client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

        GenerateRequest generateRequest = new(width, height);

        var generateResponse = await app.Client.POSTAsync<Generate, GenerateRequest>(generateRequest);
        var message = await generateResponse.Content.ReadAsStringAsync();
        Assert.True(HttpStatusCode.Created == generateResponse.StatusCode, message);

        var getResponse = await app.Client.GETAsync<Get, WorldDto>();

        Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);
        Assert.NotNull(getResponse?.Result?.Areas);
        Assert.NotEmpty(getResponse.Result.Areas);
        Assert.Equal(width * height, getResponse.Result.Areas.Count);

        var deleteResponse = await app.Client.DELETEAsync<Delete, object?>();

        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
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
