using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkflowEngine;
using WorkflowEngine.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<InMemoryDataStore>();
builder.Services.AddSingleton<WorkflowDefinitionService>();
builder.Services.AddSingleton<WorkflowInstanceService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
