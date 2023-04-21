namespace RoadmapService.Endpoints;

public class CreateRoadmapEndpoint : Endpoint<CreateRoadmapRequest, Roadmap>
{
    private readonly IRoadmapRepository roadmapRepository;

    public CreateRoadmapEndpoint(IRoadmapRepository roadmapRepository)
    {
        this.roadmapRepository = roadmapRepository;
    }

    public override void Configure()
    {
        Post("/roadmaps");
        AllowAnonymous();
        Description(x => x
            .Accepts<CreateRoadmapRequest>("application/json")
            .Produces<Roadmap>(201, "application/json"));
    }

    public override async Task HandleAsync(CreateRoadmapRequest req, CancellationToken ct)
    {
        (string title, string description) = req;
        Roadmap roadmap = new()
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description
        };

        roadmapRepository.Add(roadmap);
        await roadmapRepository.SaveChangesAsync(ct);
        HttpContext.Response.StatusCode = 201;
    }
}