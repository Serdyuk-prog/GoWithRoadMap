namespace RoadmapService.Models;

public class Roadmap
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public IEnumerable<Node> Content { get; set; } = new List<Node>();
}