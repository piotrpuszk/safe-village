using FastEndpoints;
using FastEndpoints.Testing;
using System.Net;

namespace SafeVillage.World.Tests.Endpoints;
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Theory]
    [InlineData(10, 10)]
    [InlineData(4, 10)]
    [InlineData(5, 5)]
    [InlineData(2, 3)]
    public async Task WhenCreateWorldSucceeded_ReturnWorldSuccessfully(int width, int height)
    {
        var createResponse = await app.Client.POSTAsync<SafeVillage.World.Create, CreateRequest>(new CreateRequest(width, height));

        Assert.Equal(HttpStatusCode.NoContent, createResponse.StatusCode);

        var getResponse = await app.Client.GETAsync<SafeVillage.World.Get, WorldDto>();

        Assert.Equal(HttpStatusCode.OK, getResponse.Response.StatusCode);
        Assert.NotNull(getResponse?.Result?.Areas);
        Assert.NotEmpty(getResponse.Result.Areas);
        Assert.Equal(width * height, getResponse.Result.Areas.Count);

        var deleteResponse = await app.Client.DELETEAsync<SafeVillage.World.Delete, object?>();

        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.Response.StatusCode);
    }
}
