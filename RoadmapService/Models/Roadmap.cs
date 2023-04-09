namespace RoadmapService.Models;

public class Roadmap
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required Node Root { get; init; }
}