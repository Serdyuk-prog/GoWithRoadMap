namespace RoadmapService.Endpoints;

public class SearchRoadmapEndpoint : Endpoint<SearchEndpointRequest, ResultListDto<Roadmap>>
{
    private readonly IRoadmapRepository roadmapRepository;

    public SearchRoadmapEndpoint(IRoadmapRepository roadmapRepository)
    {
        this.roadmapRepository = roadmapRepository;
    }

    public override void Configure()
    {
        Get("/roadmaps");
        AllowAnonymous();
        Description(x => x
            .Produces<ResultListDto<Roadmap>>(200, "application/json")
            .Accepts<SearchEndpointRequest>("application/json"));
    }

    public override async Task HandleAsync(SearchEndpointRequest req, CancellationToken ct)
    {
        string query = req.Search;

        if (string.IsNullOrEmpty(query))
        {
            List<Roadmap> allRoadmaps = await roadmapRepository.Get(x => true).ToListAsync(ct);
            await SendAsync(new ResultListDto<Roadmap>(allRoadmaps), 200, ct);
            return;
        }

        List<Roadmap> roadmaps = await roadmapRepository.SearchByName(query)
            .ToListAsync(cancellationToken: ct);
        await SendAsync(new ResultListDto<Roadmap>(roadmaps), 200, ct);
    }
}