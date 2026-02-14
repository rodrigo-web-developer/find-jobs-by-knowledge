var builder = DistributedApplication.CreateBuilder(args);

// Add API project (no database needed - jobs from external APIs)
var api = builder.AddProject<Projects.FindJobsByKnowledge_Api>("api");

builder.Build().Run();
