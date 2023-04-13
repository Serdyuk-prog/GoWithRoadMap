namespace RoadmapService.Requests;

public record CreateRoadmapRequest(string Title, string Description)
{
    [FromBody]
    public string Title { get; init; } = string.Empty;

    [FromBody]
    public string Description { get; init; } = string.Empty;
}