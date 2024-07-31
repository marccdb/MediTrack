var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.MediTrack_API>("meditrack-api");
builder.AddProject<Projects.MediTrack_Presentation>("meditrack-presentation");


builder.Build().Run();
