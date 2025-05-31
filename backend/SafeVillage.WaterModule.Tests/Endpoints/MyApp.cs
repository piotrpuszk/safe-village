using FastEndpoints.Testing;

namespace SafeVillage.WaterModule.Tests.Endpoints;
public class MyApp : AppFixture<Program>
{
    protected override ValueTask SetupAsync()
    {
        Client = CreateClient();
        return base.SetupAsync();
    }

    protected override ValueTask TearDownAsync()
    {
        Client.Dispose();
        return base.TearDownAsync();
    }
}
