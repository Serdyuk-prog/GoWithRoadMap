WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerDoc(settings =>
{
    settings.Title = "Roadmap API";
    settings.Version = "v1";
});

builder.Services.AddDbContext<RoadmapContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddScoped<IRoadmapRepository, RoadmapRepository>();
builder.Services.AddScoped<IRepository<Node>, NodeRepository>();
builder.Services.AddScoped<IMessageSender, MessageSender>();
builder.Services.AddFastEndpoints();
builder.Services.AddAuthentication();

builder.Services.AddSingleton(builder.Configuration.GetSection("RabbitMq").Get<RabbitMqConfig>()!);

WebApplication app = builder.Build();

app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();