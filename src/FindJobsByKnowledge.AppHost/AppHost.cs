var builder = DistributedApplication.CreateBuilder(args);

// Add PostgreSQL server
var postgres = builder.AddPostgres("postgres")
    .WithPgAdmin();

// Add the database
var jobsDb = postgres.AddDatabase("jobsdb");

// Add API project
var api = builder.AddProject<Projects.FindJobsByKnowledge_Api>("api")
    .WithReference(jobsDb);

builder.Build().Run();
