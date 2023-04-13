namespace RoadmapService.Requests;

public record UpdateRoadmapRequest(string Title, string Description, IEnumerable<UpdateRoadmapRequestContent> Content)
{
    [FromBody] public string Title { get; init; } = "";

    [FromBody] public string Description { get; init; } = "";

    [FromBody]
    public IEnumerable<UpdateRoadmapRequestContent>? Content { get; init; }
}