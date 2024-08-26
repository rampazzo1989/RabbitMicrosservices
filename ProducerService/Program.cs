using RabbitMQ.Client;
using System;
using System.Text;

namespace ProducerService
{
    /// <summary>
    /// Producer example (queue)
    /// </summary>
    public class Producer
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "testing", durable: true, exclusive: false, autoDelete: false, arguments: null);

            string message = "Hello RabbitMQ 3!";
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "", routingKey: "testing", basicProperties: null, body: body);
            Console.WriteLine(" [x] Sent {0}", message);
        }
    }
}