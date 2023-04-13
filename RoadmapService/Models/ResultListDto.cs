namespace RoadmapService.Models;

public record ResultListDto<T>(IEnumerable<T> Result);