var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Medical_Api_Auth>("medical-api-auth");

builder.AddProject<Projects.Medical_Web_Server>("medical-web-server");

builder.Build().Run();
