namespace RoadmapService.RabbitMq;

public class MessageSender : IMessageSender
{
    private readonly RabbitMqConfig config;
    private readonly ConnectionFactory connectionFactory;

    public MessageSender(RabbitMqConfig config)
    {
        this.config = config;
        connectionFactory = new ConnectionFactory
        {
            HostName = config.Host,
            UserName = config.UserName,
            Password = config.Password
        };
    }
    public void SendMessage<T>(T message, MessageType messageType)
    {
        using IModel channel = connectionFactory.CreateConnection().CreateModel();

        var (queueName, exchange, waypointRoutingKey) = messageType switch
        {
            MessageType.History => (config.HistoryQueueName, config.HistoryExchangeName, config.HistoryWaypointRoutingKey),
            MessageType.Notification => (config.NotificationQueueName, config.NotificationExchangeName, config.NotificationWaypointRoutingKey),
            _ => throw new ArgumentOutOfRangeException(nameof(message), message, null)
        };
        
        channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

        string serializedMessage = JsonSerializer.Serialize(message);
        channel.BasicPublish(exchange: exchange, routingKey: waypointRoutingKey, body: Encoding.UTF8.GetBytes(serializedMessage));
    }
}