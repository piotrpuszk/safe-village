using FastEndpoints;
using SafeVillage.SharedKernel;
using SafeVillage.Village;
using SafeVillage.Wilderness;
using SafeVillage.World;
using Serilog;
using Serilog.Templates;
using Serilog.Templates.Themes;
using System.Reflection;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up!");


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog((services, lc) => lc
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console(new ExpressionTemplate(
            // Include trace and span ids when present.
            "[{@t:HH:mm:ss} {@l:u3}{#if @tr is not null} ({substring(@tr,0,4)}:{substring(@sp,0,4)}){#end}] {@m}\n{@x}",
            theme: TemplateTheme.Code)));

List<Assembly> mediatorAssemblies = [typeof(Program).Assembly];

builder.Services.AddWorldModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddVillageModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddWildernessModuleServices(builder.Configuration, mediatorAssemblies);

builder.Services.AddMediatR(e => e.RegisterServicesFromAssemblies([.. mediatorAssemblies]));
builder.Services.AddHandlerLoggingBehavior();

builder.Services.AddFastEndpoints();

var app = builder.Build();

//app.UseAuthentication();
//app.UseAuthorization();

app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

app.Run();


public partial class Program { } //for tests