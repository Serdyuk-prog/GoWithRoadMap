# Use official RabbitMQ image as base
FROM rabbitmq:latest

# Set environment variables
ENV RABBITMQ_DEFAULT_USER user
ENV RABBITMQ_DEFAULT_PASS password

# Expose ports
EXPOSE 5672 15672

FROM openjdk:18-jre-slim
RUN mkdir /app
WORKDIR /app
COPY target/TestHistory-0.0.1-SNAPSHOT.jar /app/TestHistory-0.0.1-SNAPSHOT.jar
CMD ["java", "-Xms128m", "-Xmx1024m", "-jar", "/app/TestHistory-0.0.1-SNAPSHOT.jar"]

