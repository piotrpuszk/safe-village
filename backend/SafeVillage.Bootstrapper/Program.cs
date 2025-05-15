using System.Reflection;
using FastEndpoints;
using SafeVillage.World;

var builder = WebApplication.CreateBuilder(args);

List<Assembly> mediatorAssemblies = [typeof(Program).Assembly];

builder.Services.AddWorldModuleServices(builder.Configuration, mediatorAssemblies);

builder.Services.AddMediatR(e => e.RegisterServicesFromAssemblies([.. mediatorAssemblies]));
builder.Services.AddFastEndpoints();

var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseFastEndpoints();

app.Run();
