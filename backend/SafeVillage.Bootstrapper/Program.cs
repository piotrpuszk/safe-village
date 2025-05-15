using FastEndpoints;
using SafeVillage.Village;
using SafeVillage.Wilderness;
using SafeVillage.World;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

List<Assembly> mediatorAssemblies = [typeof(Program).Assembly];

builder.Services.AddWorldModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddVillageModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddWildernessModuleServices(builder.Configuration, mediatorAssemblies);

builder.Services.AddMediatR(e => e.RegisterServicesFromAssemblies([.. mediatorAssemblies]));
builder.Services.AddFastEndpoints();

var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

app.Run();


public partial class Program { } //for tests