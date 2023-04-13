namespace RoadmapService.Requests;

public record SearchEndpointRequest(string Search)
{
    [FromQueryParams]
    public string Search { get; init; } = string.Empty;
}