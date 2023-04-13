package com.example.history.rabbitmq;

import com.example.history.config.RabbitMQConfig;
import com.example.history.model.WayPoint;
import com.example.history.repositories.WayPointRepository;
import org.springframework.amqp.rabbit.annotation.RabbitListener;
import org.springframework.beans.factory.annotation.Autowired;

public class RabbitMQReciever {
    // Внедряем репозиторий WayPointRepository
    @Autowired
    private WayPointRepository wayPointRepository;

    // Метод для прослушивания сообщений из очереди нового WayPoint
    @RabbitListener(queues = RabbitMQConfig.NEW_WAYPOINT_QUEUE)
    public void receiveNewWayPoint(WayPoint newWayPoint) {
        // Сохраняем новый WayPoint в базу данных
        wayPointRepository.save(newWayPoint);
        System.out.println("New WayPoint received from rabbitmq and saved to database: " + newWayPoint);
    }
}
