using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQ.Consumer
{
    public static class Consumer
    {
        public static void Consume(IModel channel)
        {
            EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                System.Console.WriteLine(message);
            };
            channel.BasicConsume("demo-queue", true, consumer);
        }
    }
}