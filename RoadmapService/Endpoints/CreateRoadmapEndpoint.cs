namespace RoadmapService.Endpoints;

public class CreateRoadmapEndpoint : Endpoint<CreateRoadmapRequest, Roadmap>
{
    public override void Configure()
    {
        Post("/roadmaps");
    }

    public override Task HandleAsync(CreateRoadmapRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}