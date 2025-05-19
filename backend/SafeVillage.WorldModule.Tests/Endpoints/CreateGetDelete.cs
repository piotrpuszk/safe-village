using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.WorldModule.Dtos;
using SafeVillage.WorldModule.Endpoints;
using System.Net;

namespace SafeVillage.WorldModule.Tests.Endpoints;
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(4, 10)]
    [InlineData(5, 5)]
    [InlineData(2, 3)]
    public async Task WhenCreateWorldSucceeded_ReturnWorldSuccessfully(int width, int height)
    {
        var createResponse = await app.Client.POSTAsync<Create, CreateRequest>(new CreateRequest(width, height));

        Assert.Equal(HttpStatusCode.NoContent, createResponse.StatusCode);

        var getResponse = await app.Client.GETAsync<Get, WorldDto>();

        Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);
        Assert.NotNull(getResponse?.Result?.Areas);
        Assert.NotEmpty(getResponse.Result.Areas);
        Assert.Equal(width * height, getResponse.Result.Areas.Count);
        var containsVillage = getResponse.Result.Areas.Select(e => e.Location?.Type).Contains("village");
        var containsWilderness = getResponse.Result.Areas.Select(e => e.Location?.Type).Contains("wilderness");
        Assert.True(containsWilderness || containsVillage);

        var deleteResponse = await app.Client.DELETEAsync<Delete, object?>();

        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
    }
}
