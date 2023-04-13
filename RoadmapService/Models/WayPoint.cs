namespace RoadmapService.Models;

public record WayPoint(Guid id, string title, WayPointKind kind, Guid roadmapId);