using Application;
using Database.Seeders;
using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder();

builder.Host.UseSerilog(
    (ctx, lc) =>
    {
        lc.ReadFrom
            .Configuration(ctx.Configuration)
            .Enrich.FromLogContext()
            .Enrich.WithExceptionDetails()
            .WriteTo.Console();
    }
);

var config = builder.Configuration;
builder.Services.ConfigureServices(config);

var app = builder.Build();
var env = app.Environment;

if (args.Length > 0 && args[0] == "seed")
{
    using var scope = app.Services.CreateScope();
    var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    await dbSeeder.Seed();
    return;
}

app.ConfigureApplication(env);

await app.RunAsync();
