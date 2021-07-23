using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start!");
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(
                "demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                System.Console.WriteLine(message);
            };
            channel.BasicConsume("demo-queue", true, consumer);
            Console.ReadLine();

            Console.WriteLine("done!");

        }
    }
}
