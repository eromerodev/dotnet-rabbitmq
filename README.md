# RabbitMQ and .NET

RabbitMQ provides a .NET client that makes it easy for .NET applications to connect to RabbitMQ and perform common operations.

## What is RabbitMQ?

RabbitMQ is an open-source message broker software that implements the Advanced Message Queuing Protocol (AMQP). It allows applications to send and receive messages to/from a queue, facilitating message-driven processing architecture. RabbitMQ can be used to handle work queues, implement publisher/subscriber patterns, and more.

### RabbitMQ Client

```bash
dotnet add package RabbitMQ.Client
```

The integration with .NET, particularly using the RabbitMQ.Client library, makes it straightforward for .NET applications to produce and consume messages, making it a popular choice for message-driven architectures in the .NET ecosystem.

## Dotnet commands:

```bash
# Create a new Web API project (publisher).
dotnet new webapi -n Payment.Publisher

# Create a new console project (consumer).
dotnet new console -n Payment.Consumer

# Create a new solution file and then add the project to it.
dotnet new sln -n PaymentRabbitMQ

dotnet sln PaymentRabbitMQ.sln add Payment.Publisher/Payment.Publisher.csproj
dotnet sln PaymentRabbitMQ.sln add Payment.Consumer/Payment.Consumer.csproj

```
### How to Run

```bash
# Run each project (publisher and consumer).
dotnet run
```