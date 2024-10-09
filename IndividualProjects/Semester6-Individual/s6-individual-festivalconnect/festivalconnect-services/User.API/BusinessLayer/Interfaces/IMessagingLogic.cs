using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IMessagingLogic
    {
        public IConnection Connect();
        public void Publish<T>(string exchangeName, string routingKey, T data);
        public void Subscribe(string exchangeName, string queueName, string routingKey);
        public void Subscribe<T>(string exchangeName, string queueName, string routingKey, Action<T> handler);
    }
}
