// Services/RabbitMQService.cs
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using Payment.Models;

namespace Payment.Services
{
    public class RabbitMQService
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "payments";
        private IConnection _connection;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = _hostname };
            _connection = factory.CreateConnection();
        }

        public void Publish(CreatePayment payment)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var jsonPayload = JsonConvert.SerializeObject(payment);
                var body = Encoding.UTF8.GetBytes(jsonPayload);

                channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);
            }
        }
    }
}


