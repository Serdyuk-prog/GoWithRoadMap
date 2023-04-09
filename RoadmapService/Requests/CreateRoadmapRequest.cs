namespace RoadmapService.Requests;

public class CreateRoadmapRequest
{
    [FromBody]
    public string Title { get; set; } = string.Empty;

    [FromBody] 
    public string Description { get; set; } = string.Empty;
}