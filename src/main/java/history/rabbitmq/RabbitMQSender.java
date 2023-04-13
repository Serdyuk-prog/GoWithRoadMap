package history.rabbitmq;

import history.config.RabbitMQConfig;
import history.model.WayPoint;
import org.springframework.amqp.rabbit.core.RabbitTemplate;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RabbitMQSender {
    // Внедряем шаблон для работы с rabbitmq
    @Autowired
    private RabbitTemplate rabbitTemplate;

    // Метод для отправки WayPoint в очередь через обменник с ключом маршрутизации
    public void sendWayPoint(WayPoint wayPoint) {
        rabbitTemplate.convertAndSend(RabbitMQConfig.WAYPOINT_EXCHANGE, RabbitMQConfig.WAYPOINT_ROUTING_KEY, wayPoint);
        System.out.println("WayPoint sent to rabbitmq: " + wayPoint);
    }
}
