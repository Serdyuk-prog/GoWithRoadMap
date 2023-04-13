namespace RoadmapService.Requests;

public record UpdateRoadmapRequestContent(Guid Id, string Title, string Description, NodeKind Kind, NodeStatus Status);