using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace RabbitMQ.Producer
{
    public static class Producer
    {
        public static void publish(IModel channel)
        {
            channel.QueueDeclare("demo-queue", true, false, false, null);


            int count = 0;
            while (true)
            {
                var message = new { Name = "producer", Message = $"Hello consumer{count}" };
                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
                channel.BasicPublish("", "demo-queue", null, body);
                count++;
                Thread.Sleep(1000);
            }
        }
    }
}

