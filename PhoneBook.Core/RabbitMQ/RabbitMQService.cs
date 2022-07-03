using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RabbitMQ
{
    public class RabbitMQService
    {
        public const string queueName = "location-report-action";
        public IConnection GetRabbitMQConnection()
        {

            // Factory nesnesi üstünden RabbitMQ'ya bir bağlantı açacağız
            var factory = new ConnectionFactory() { HostName = "localhost" };
            factory.AutomaticRecoveryEnabled = true;
            factory.RequestedHeartbeat =new TimeSpan(0,0,10);

            return factory.CreateConnection();

        }
    }



}
