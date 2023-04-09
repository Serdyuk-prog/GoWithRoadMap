namespace RoadmapService.Endpoints;

public class SearchRoadmapEndpoint : Endpoint<SearchEndpointRequest, ResultListDto<Roadmap>>
{
    public override void Configure()
    {
        Get("/roadmaps");
    }
    
    public override Task HandleAsync(SearchEndpointRequest req, CancellationToken ct)
    {
        return base.HandleAsync(req, ct);
    }
}