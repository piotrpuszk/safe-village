using FastEndpoints.Testing;

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
        Client.Dispose();
        await base.TearDownAsync();
    }
}
