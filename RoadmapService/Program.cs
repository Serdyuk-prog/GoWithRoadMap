WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RoadmapContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("")));
builder.Services.AddFastEndpoints();

WebApplication app = builder.Build();

app.UseFastEndpoints();

app.Run();