using MessagingService.Common;
using MessagingService.Features;
using MessagingService.Kernel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddConfiguredMassTransit(builder.Configuration);
builder.Services.ConfigureDbContexts(builder.Configuration);
builder.Services.ConfigureFeatures();
builder.Services.ConfigureKernel();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();