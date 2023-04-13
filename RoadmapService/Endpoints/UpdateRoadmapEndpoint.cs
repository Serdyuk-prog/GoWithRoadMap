namespace RoadmapService.Endpoints;

public class UpdateRoadmapEndpoint : Endpoint<UpdateRoadmapRequest>
{
    private readonly IRoadmapRepository roadmapRepository;
    private readonly IMessageSender messageSender;

    public UpdateRoadmapEndpoint(IRoadmapRepository roadmapRepository, IMessageSender messageSender)
    {
        this.roadmapRepository = roadmapRepository;
        this.messageSender = messageSender;
    }

    public override void Configure()
    {
        Patch("/roadmaps/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(UpdateRoadmapRequest req, CancellationToken ct)
    {
        Guid id = Route<Guid>("Id");
        (string? title, string? description, IEnumerable<UpdateRoadmapRequestContent>? contents) = req;

        Roadmap? roadmap = await roadmapRepository.GetId(id, ct);
        if (roadmap is null)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await HttpContext.Response.WriteAsync($"Roadmap with id {id} was not found", cancellationToken: ct);
            return;
        }

        List<UpdateRoadmapRequestContent> requestContents = contents.ToList();
        UpdateRoadmap(roadmap, title, description, requestContents);
        SendHistoryMessages(roadmap, requestContents);

        if (roadmap.Content.Where(x => x.Kind is NodeKind.Required).All(x => x.Status is NodeStatus.Completed or NodeStatus.Skipped))
        {
            WayPoint wayPoint = new(Guid.NewGuid(), roadmap.Title, WayPointKind.RoadmapCompleted, roadmap.Id);
            messageSender.SendMessage(wayPoint, MessageType.History);
            messageSender.SendMessage<string>($"{roadmap.Id}: roadmap \"{roadmap.Title}\" was completed!", MessageType.Notification);
        }

        HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
    }

    private static void UpdateRoadmap(Roadmap roadmap, string title, string description, IEnumerable<UpdateRoadmapRequestContent> contents)
    {
        
        
        roadmap.Title = title;
        roadmap.Description = description;
        roadmap.Content = contents.Select(x => new Node
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description,
            Kind = x.Kind,
            Status = x.Status
        });
    }

    private void SendHistoryMessages(Roadmap roadmap, 
        IEnumerable<UpdateRoadmapRequestContent> contents)
    {
        foreach (UpdateRoadmapRequestContent content in contents)
        {
            Node? node = roadmap.Content.FirstOrDefault(x => x.Id == content.Id);

            if (node is null)
            {
                messageSender.SendMessage<string>($"{content.Id}: New node with title \"{content.Title}\" was added", MessageType.Notification);
                continue;
            }

            if (node.Status == content.Status) continue;
            WayPoint wayPoint = new(content.Id, content.Title, WayPointKind.NodeCompleted, roadmap.Id);
            messageSender.SendMessage(wayPoint, MessageType.History);
            messageSender.SendMessage<string>($"{roadmap.Id}: node \"{content.Title}\" was completed!", MessageType.Notification);
        }
    }
}
