using FindJobsByKnowledge.Api;
using FindJobsByKnowledge.Api.Services;
using FindJobsByKnowledge.Api.Services.Datasources;
using FindJobsByKnowledge.Domain.Services;
using FindJobsByKnowledge.Repository.Data;
using FindJobsByKnowledge.Repository.Repositories;
using FindJobsByKnowledge.TorreAI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add HttpClient for external API calls
builder.Services.AddHttpClient();

// Database context
builder.AddNpgsqlDbContext<ApplicationDbContext>("postgresdb");

// Register repositories
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionaryRepository, QuestionaryRepository>();

// Register job datasources

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<IJobDatasource, MockJobDatasource>();
}

builder.Services.AddScoped<IJobDatasource, TorreAIJobDatasource>();

// Register services
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IQuestionaryService, QuestionaryService>();

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

// Auto-migrate database and seed questions
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    await db.Database.MigrateAsync();
    await QuestionSeeder.SeedAsync(db);
}

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
