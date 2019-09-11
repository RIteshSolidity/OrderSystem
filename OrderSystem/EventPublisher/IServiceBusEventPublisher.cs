using OrderSystem.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;

namespace OrderSystem.EventPublisher
{
    public interface IServiceBusEventPublisher
    {
        Task PublishEvent(IEvents @event);
    }

    public class ServiceBusEventPublisher : IServiceBusEventPublisher
    {
        private string _connectionString;
        private string _topicName;
        private TopicClient client;

        public ServiceBusEventPublisher(string ConnectionString, string TopicName)
        {
            _connectionString = ConnectionString;
            _topicName = TopicName;
            client = new TopicClient(_connectionString, _topicName);
        }
        public async Task PublishEvent(IEvents @event)
        {
            string messageString;
            Message msg = new Message();
            switch (@event) {
                case OrderEvents.OrderPlaced op: {
                        var settings = new JsonSerializerSettings();
                        settings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;

                        messageString = JsonConvert.SerializeObject((OrderEvents.OrderPlaced)@event ,settings);

                        msg.Body = System.Text.Encoding.ASCII.GetBytes(messageString);
                        break;
                    }
            }

           await  client.SendAsync(msg);
           
        }
    }
}
