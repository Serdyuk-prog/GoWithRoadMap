# Взаимодействие между сервисами

1. Frontend
   - Использует REST API у сервисов History и RoadMap;
2. RoadMap
   - Предоставляет REST API для работы с картами;
   - Публикует события в очередь сообщений (RabbitMQ);
   - Хранит карты в своей базе данных;
3. History
   - Предоставляет REST API для получения истории;
   - Потребляет события из очереди сообщений;
   - Хранит историю прохождения карт в своей базе данных;
4. Notification
   - Потребляет события из очереди сообщений;
   - Отправляет уведомления (через Telegram, но кому отправляет непонятно, пользователь то только один. Пусть будет параметр в конфигурации);

## Как организовать передачу событий через шину сообщений ?

[Материалы](https://www.rabbitmq.com/getstarted.html)

<details>
  <summary>Hints</summary>

Простой вариант для реализации:

1. Нужный тип для exchange - `fanout` (Назовем exchange как "RoadMapEvents");
2. Необходимо объявить две очереди: отдельно для History и Notification. И привязать их к "RoadMapEvents";
3. RoadMap публикует события в exchange, а History и Notification их потребляет: каждый из своей очереди;

</details>