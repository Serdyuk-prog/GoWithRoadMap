namespace RoadmapService.Models;

public class Node
{
    public required Guid Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required NodeKind Kind { get; set; }
    public required NodeStatus Status { get; set; }
}