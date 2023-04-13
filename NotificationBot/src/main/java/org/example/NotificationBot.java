package org.example;

import com.rabbitmq.client.*;
import org.telegram.telegrambots.bots.TelegramLongPollingBot;
import org.telegram.telegrambots.meta.api.methods.send.SendMessage;
import org.telegram.telegrambots.meta.exceptions.TelegramApiException;

public class NotificationBot extends TelegramLongPollingBot {

    private static final String QUEUE_NAME = "notification_queue";
    private final String BOT_TOKEN;
    private static final String BOT_USERNAME = "RoadMapNotificationBot";

    public NotificationBot(String token) {

        BOT_TOKEN = token;
        try {
            ConnectionFactory factory = new ConnectionFactory();
            factory.setHost("localhost");
            Connection connection = factory.newConnection();
            Channel channel = connection.createChannel();

            channel.queueDeclare(QUEUE_NAME, false, false, false, null);
            System.out.println("Waiting for messages from Rabbitmq...");

            DeliverCallback deliverCallback = (consumerTag, delivery) -> {
                String message = new String(delivery.getBody(), "UTF-8");
                System.out.println("Received message: " + message);

                String[] parts = message.split(":", 2);
                if (parts.length == 2) {
                    long userId = Long.parseLong(parts[0]);
                    String text = parts[1];

                    SendMessage sendMessage = new SendMessage();
                    sendMessage.setChatId(userId);
                    sendMessage.setText(text);

                    try {
                        execute(sendMessage);
                        System.out.println("Sent message to user: " + userId);
                    } catch (TelegramApiException e) {
                        e.printStackTrace();
                    }
                } else {
                    System.out.println("Invalid message format");
                }
            };

            channel.basicConsume(QUEUE_NAME, true, deliverCallback, consumerTag -> {});
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    @Override
    public String getBotToken() {
        return BOT_TOKEN;
    }

    @Override
    public String getBotUsername() {
        return BOT_USERNAME;
    }

    @Override
    public void onUpdateReceived(org.telegram.telegrambots.meta.api.objects.Update update) {
    }

    public static void main(String[] args) {
        NotificationBot bot = new NotificationBot(args[0]);
    }
}
