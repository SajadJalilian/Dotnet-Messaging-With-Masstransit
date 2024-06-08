using MessagingService.Common;
using MessagingService.Kernel;
using MessagingService.Providers;

var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{env}.json")
    .AddEnvironmentVariables()
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseConfiguration(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguredMassTransit(builder.Configuration);
builder.Services.AddConfiguredRedis(builder.Configuration);
builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureProviders();
builder.Services.ConfigureKernel();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();