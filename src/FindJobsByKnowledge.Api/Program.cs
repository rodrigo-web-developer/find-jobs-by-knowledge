using FindJobsByKnowledge.Repository.Data;
using FindJobsByKnowledge.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Add PostgreSQL with Aspire
builder.AddNpgsqlDbContext<ApplicationDbContext>("jobsdb");

// Add repositories
builder.Services.AddScoped<IJobRepository, JobRepository>();

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
