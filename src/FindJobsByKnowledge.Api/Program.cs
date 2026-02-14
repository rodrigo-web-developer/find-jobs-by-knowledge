using FindJobsByKnowledge.Api.Services;
using FindJobsByKnowledge.Api.Services.Datasources;
using FindJobsByKnowledge.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add HttpClient for external API calls
builder.Services.AddHttpClient();

// Register job datasource - only Mock datasource

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IJobDatasource, MockJobDatasource>();
}

// Register job service (aggregates from all datasources)
builder.Services.AddScoped<IJobService, JobService>();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
