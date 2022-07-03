using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RabbitMQ
{
    public class RabbitMQListener
    {
        private readonly RabbitMQService _rabbitMQService;
        public delegate void ReportMessageRequest(RabbitMQPackage package);
        public event ReportMessageRequest OnReportMessageRequestReceived;

        public RabbitMQListener()
        {
            string queueName = RabbitMQService.queueName;
            _rabbitMQService = new RabbitMQService();

            var connection = _rabbitMQService.GetRabbitMQConnection();
            var channel = connection.CreateModel();

            var consumer = new EventingBasicConsumer(channel);
            
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                RabbitMQPackage package = JsonConvert.DeserializeObject<RabbitMQPackage>(message);
                if (OnReportMessageRequestReceived != null)
                    OnReportMessageRequestReceived(package);
            };

            channel.BasicConsume(queueName, true, consumer);
        }
    }
}
