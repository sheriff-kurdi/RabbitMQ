using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start    !");
            ConnectionFactory factory = new ConnectionFactory()
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();
            Producer.publish(channel);
            Console.ReadLine();

         

        }
    }
}
