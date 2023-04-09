namespace RoadmapService.Models;

public class Node
{
    public required Guid Id { get; init; }
    public required Guid ParentId { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
    public required NodeKind Kind { get; init; }
    public required NodeStatus Status { get; init; }
    public required IEnumerable<Node> Children { get; init; }
}