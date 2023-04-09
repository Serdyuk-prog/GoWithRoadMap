namespace RoadmapService.Requests;

public class SearchEndpointRequest
{
    [FromQueryParams] 
    public string Search { get; set; } = string.Empty;
}