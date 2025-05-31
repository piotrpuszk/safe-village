using FastEndpoints;
using SafeVillage.SharedKernel;
using SafeVillage.VillageModule;
using SafeVillage.WildernessModule;
using SafeVillage.WorldModule;
using Serilog;
using Serilog.Templates;
using Serilog.Templates.Themes;
using System.Reflection;
using SafeVillage.UserModule;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SafeVillage.WorldGeneratorModule;
using SafeVillage.WaterModule;

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
            "[{@t:HH:mm:ss} {@l:u3}{#if @tr is not null} ({substring(@tr,0,4)}:{substring(@sp,0,4)}){#end}] {@m}\n{@x}",
            theme: TemplateTheme.Code)));

List<Assembly> mediatorAssemblies = [typeof(Program).Assembly];

builder.Services.AddWorldModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddWorldGeneratorModuleServices(builder.Configuration, mediatorAssemblies);

builder.Services.AddVillageModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddWildernessModuleServices(builder.Configuration, mediatorAssemblies);
builder.Services.AddWaterModuleServices(builder.Configuration, mediatorAssemblies);

builder.Services.AddUserModuleServices(builder.Configuration, mediatorAssemblies);

builder.Services.AddMediatR(e => e.RegisterServicesFromAssemblies([.. mediatorAssemblies]));
builder.Services.AddHandlerLoggingBehavior();

builder.Services.AddFastEndpoints();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(e =>
    {
        var tokenKey = builder.Configuration["TokenKey"];
        e.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });
builder.Services.AddAuthorization();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultExceptionHandler();
app.UseFastEndpoints();

app.Run();


public partial class Program { } //for tests