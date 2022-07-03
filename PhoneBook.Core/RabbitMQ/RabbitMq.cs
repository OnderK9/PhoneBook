using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Core.RabbitMQ
{
    public class RabbitMq
    {
        public static void SendMessage(string guid)
        {
            var service =new RabbitMQService();

            using (var connection = service.GetRabbitMQConnection())
            {
                // sonrasında kanal tanımlama ve mesaj gönderme işi için gerekli nesneleri üreteceğiz
                using (var channel = connection.CreateModel())
                {
                    string queueName = RabbitMQService.queueName;
                    // Bir kuyruk tanımladık. Kargonun durum değişikliği ile alakalı bir kuyruk gibi düşünelim
                    channel.QueueDeclare(queue: queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    // Kuyruğu JSON olarak serileştirilmiş bir nesne koyalım. Kobay nesnemiz Package türünden bir örnek.
                    var package = JsonConvert.SerializeObject(new RabbitMQPackage
                    {
                        Data = guid,
                        State = "Ready",
                        Time = DateTime.Now.ToString()
                    });
                    // nesne içeriğini kanala yazmak için Byte[] dizisine çeviriyoruz
                    var body = Encoding.UTF8.GetBytes(package);

                    // routingKey bilgisi ile de yukarıda tanımlanan kanala mesajımızı bırakalım
                    channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: body);
                }
            }
        }
    }



}
