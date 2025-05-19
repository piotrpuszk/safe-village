using FastEndpoints;
using FastEndpoints.Testing;
using SafeVillage.WorldModule.Endpoints;

namespace SafeVillage.WorldModule.Tests.Endpoints;
public class MyApp : AppFixture<Program>
{
    protected override ValueTask SetupAsync()
    {
        Client = CreateClient(); 
        return base.SetupAsync();
    }

    protected override async ValueTask TearDownAsync()
    {
        await Client.DELETEAsync<Delete, HttpResponseMessage>();
        Client.Dispose();
        await base.TearDownAsync();
    }
}
