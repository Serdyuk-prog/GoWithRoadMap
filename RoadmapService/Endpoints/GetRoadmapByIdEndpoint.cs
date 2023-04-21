namespace RoadmapService.Endpoints;

public class GetRoadmapByIdEndpoint : EndpointWithoutRequest<Roadmap>
{
    private readonly IRoadmapRepository roadmapRepository;

    public GetRoadmapByIdEndpoint(IRoadmapRepository roadmapRepository)
    {
        this.roadmapRepository = roadmapRepository;
    }

    public override void Configure()
    {
        Get("/roadmaps/{Id}");
        AllowAnonymous();
        Description(x => x.WithName("GetRoadmapById")
            .Produces<Roadmap>(200, "application/json")
            .Produces(404));
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        Guid id = Route<Guid>("Id");

        Roadmap? roadmap = await roadmapRepository.GetId(id, ct);

        if (roadmap is null)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await HttpContext.Response.WriteAsync($"Roadmap with id {id} was not found", cancellationToken: ct);
            return;
        }

        await SendAsync(roadmap, 200, ct);
    }
}