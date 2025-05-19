using FastEndpoints;
using FastEndpoints.Testing;
using System.Net;

namespace SafeVillage.VillageModule.Tests.Endpoints;
public class CreateGetDelete(MyApp app) : TestBase<MyApp>
{
    [Fact]
    public async Task WhenValidName_ThenCreateVillage_ThenGetThisVillage_ThenThisDeleteVillage()
    {
        var validName = "my test village";

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
}
