package com.example.history.config;

import org.springframework.amqp.core.Binding;
import org.springframework.amqp.core.BindingBuilder;
import org.springframework.amqp.core.Queue;
import org.springframework.amqp.core.TopicExchange;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

@Configuration
public class RabbitMQConfig {
    // Название очереди для отправки WayPoint
    public static final String WAYPOINT_QUEUE = "waypoint_queue";
    // Название обменника для отправки WayPoint
    public static final String WAYPOINT_EXCHANGE = "waypoint_exchange";
    // Ключ маршрутизации для отправки WayPoint
    public static final String WAYPOINT_ROUTING_KEY = "waypoint_routing_key";
    // Название очереди для получения нового WayPoint
    public static final String NEW_WAYPOINT_QUEUE = "new_waypoint_queue";
    // Название обменника для получения нового WayPoint
    public static final String NEW_WAYPOINT_EXCHANGE = "new_waypoint_exchange";
    // Ключ маршрутизации для получения нового WayPoint
    public static final String NEW_WAYPOINT_ROUTING_KEY = "new_waypoint_routing_key";

    // Метод для создания очереди WayPoint
    @Bean
    public Queue waypointQueue() {
        return new Queue(WAYPOINT_QUEUE);
    }

    // Метод для создания обменника WayPoint
    @Bean
    public TopicExchange waypointExchange() {
        return new TopicExchange(WAYPOINT_EXCHANGE);
    }

    // Метод для создания связи между очередью и обменником WayPoint
    @Bean
    public Binding waypointBinding(Queue waypointQueue, TopicExchange waypointExchange) {
        return BindingBuilder.bind(waypointQueue).to(waypointExchange).with(WAYPOINT_ROUTING_KEY);
    }

    // Метод для создания очереди нового WayPoint
    @Bean
    public Queue newWaypointQueue() {
        return new Queue(NEW_WAYPOINT_QUEUE);
    }

    // Метод для создания обменника нового WayPoint
    @Bean
    public TopicExchange newWaypointExchange() {
        return new TopicExchange(NEW_WAYPOINT_EXCHANGE);
    }

    // Метод для создания связи между очередью и обменником нового WayPoint
    @Bean
    public Binding newWaypointBinding(Queue newWaypointQueue, TopicExchange newWaypointExchange) {
        return BindingBuilder.bind(newWaypointQueue).to(newWaypointExchange).with(NEW_WAYPOINT_ROUTING_KEY);
    }
}
