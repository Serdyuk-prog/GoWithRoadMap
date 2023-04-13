namespace RoadmapService.RabbitMq;

public interface IMessageSender
{
    void SendMessage<T>(T message, MessageType messageType);
}