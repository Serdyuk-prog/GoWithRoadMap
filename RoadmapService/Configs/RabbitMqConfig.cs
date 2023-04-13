namespace RoadmapService.Configs;

public class RabbitMqConfig
{
    public string Host { get; set; } = "";
    public string UserName { get; set; } = "";
    public string Password { get; set; } = "";
    public string HistoryQueueName { get; set; } = "";
    public string HistoryExchangeName { get; set; } = "";
    public string HistoryWaypointRoutingKey { get; set; } = "";
    public string NotificationQueueName { get; set; } = "";
    public string NotificationExchangeName { get; set; } = "";
    public string NotificationWaypointRoutingKey { get; set; } = "";

}