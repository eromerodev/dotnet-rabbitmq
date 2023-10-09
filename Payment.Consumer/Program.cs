// Program.cs
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using Payment.Event;

class Program
{
  private const string QueueName = "payments";

  static void Main()
  {
    var factory = new ConnectionFactory() { HostName = "localhost" };
    using var connection = factory.CreateConnection();
    using var channel = connection.CreateModel();
    channel.QueueDeclare(queue: QueueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
      var body = ea.Body.ToArray();
      var jsonPayload = Encoding.UTF8.GetString(body);
      var payment = JsonConvert.DeserializeObject<PaymentMessage>(jsonPayload);
      if (payment is not null)
      {
        Console.WriteLine("Received Payment:");
        Console.WriteLine($"CardNumber: {payment.CardNumber}");
        Console.WriteLine($"Amount: {payment.Amount}");
        Console.WriteLine($"Currency: {payment.Currency}");
      }
    };

    channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);
    Console.WriteLine("Press [enter] to exit.");
    Console.ReadLine();
  }
}
