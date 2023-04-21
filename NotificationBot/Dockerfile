FROM openjdk:18-jre-slim
RUN mkdir /app
WORKDIR /app
COPY target/notification_bot.jar /app/notification_bot.jar
ENV BOT_TOKEN=your_bot_token
CMD ["java", "-Xms128m", "-Xmx1024m", "-jar", "/app/notification_bot.jar"]
