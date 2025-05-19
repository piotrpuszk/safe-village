using FastEndpoints;
using FastEndpoints.Testing;
using System.Net;

namespace SafeVillage.Wilderness.Tests.Endpoints;
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidArguments_ThenCreateWilderness_ThenGetThisWilderness_ThenDeleteThisWilderness()
    {
        var validInhabitPoints = 20;

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
}
