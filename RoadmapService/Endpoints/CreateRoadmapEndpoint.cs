namespace RoadmapService.Endpoints;

public class CreateRoadmapEndpoint : Endpoint<CreateRoadmapRequest, Roadmap>
{
    private readonly IRoadmapRepository roadmapRepository;
    private readonly IMessageSender messageSender;


    public CreateRoadmapEndpoint(IRoadmapRepository roadmapRepository, IMessageSender messageSender)
    {
        this.roadmapRepository = roadmapRepository;
        this.messageSender = messageSender;
    }

    public override void Configure()
    {
        Post("/roadmaps");
        AllowAnonymous();
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
    }
}