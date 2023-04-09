namespace RoadmapService.Endpoints;

public class GetRoadmapByIdEndpoint : EndpointWithoutRequest<Roadmap>
{
    public override void Configure()
    {
        Get("/roadmap/{Id}");
    }

    public override Task HandleAsync(CancellationToken ct)
    {
        return base.HandleAsync(ct);
    }
}