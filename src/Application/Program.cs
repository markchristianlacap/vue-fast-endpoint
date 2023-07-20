using Application;

var builder = WebApplication.CreateBuilder();
var config = builder.Configuration;
builder.Services.ConfigureServices(config);

var app = builder.Build();
var env = app.Environment;
app.ConfigureApplication(env);

await app.RunAsync();
