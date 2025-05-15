using FastEndpoints;
using FastEndpoints.Testing;

namespace SafeVillage.World.Tests.Endpoints;
public class MyApp : AppFixture<Program>
{
    protected override ValueTask SetupAsync()
    {
        Client = CreateClient(); 
        return base.SetupAsync();
    }

    protected override async ValueTask TearDownAsync()
    {
        await Client.DELETEAsync<SafeVillage.World.Delete, HttpResponseMessage>();
        Client.Dispose();
        await base.TearDownAsync();
    }
}
