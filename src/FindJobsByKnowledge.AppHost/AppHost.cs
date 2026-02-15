var builder = DistributedApplication.CreateBuilder(args);

// Add PostgreSQL for questions and questionaries
var postgres = builder.AddPostgres("postgres")
    .AddDatabase("postgresdb");

// Add API project with database reference
var api = builder.AddProject<Projects.FindJobsByKnowledge_Api>("api")
    .WithReference(postgres)
    .WaitFor(postgres);

builder.Build().Run();
