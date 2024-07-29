var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MediTrack_API>("meditrack-api");


builder.Build().Run();
