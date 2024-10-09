using BusinessLayer.Interfaces;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BusinessLayer.Logic
{
    public class MessagingLogic : IMessagingLogic
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private IModel _channel;

        public MessagingLogic(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = Connect();
            _channel = _connection.CreateModel();
        }

        public IConnection Connect()
        {
            try
            {
                var connectionRabbitMQ = _configuration["RABBITMQ-IMAGE"];
                var factory = new ConnectionFactory
                {
                    Uri = new Uri(connectionRabbitMQ)
                };
                return factory.CreateConnection();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception("Tries limit reached");
            }
            
            /*int tries = 0;
            int amountOfTries = 5;
            TimeSpan timeout = TimeSpan.FromSeconds(0);
            while(tries < amountOfTries)
            {
                try
                {
                    var connectionRabbitMQ = _configuration["RABBITMQ-IMAGE"];
                    var factory = new ConnectionFactory
                    {
                        Uri = new Uri(connectionRabbitMQ)
                    };
                    return factory.CreateConnection();
                }
                catch (Exception)
                {
                    timeout = TimeSpan.FromSeconds(30);
                    tries++;
                    Task.Delay(timeout).Wait();
                    Console.WriteLine($"Trying amount: {tries} of {amountOfTries}");
                }
            }
            throw new Exception("Tries limit reached");*/
        }

        public void Publish<T>(string exchangeName, string routingKey, T data)
        {
            _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);
            var jsonMessage = JsonSerializer.Serialize(data);
            var body = Encoding.UTF8.GetBytes(jsonMessage);
            _channel.BasicPublish(exchange: exchangeName, routingKey: routingKey, basicProperties: null, body: body);
        }

        public void Subscribe(string exchangeName, string queueName, string routingKey)
        {
            _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var receivedMessage = Encoding.UTF8.GetString(body);
                Console.WriteLine(receivedMessage);
            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

        public void Subscribe<T>(string exchangeName, string queueName, string routingKey, Action<T> handler)
        {
            _channel.ExchangeDeclare(exchange: exchangeName, type: ExchangeType.Direct);
            _channel.QueueDeclare(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
            _channel.QueueBind(queue: queueName, exchange: exchangeName, routingKey: routingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var receivedMessage = Encoding.UTF8.GetString(body);
                Console.WriteLine(receivedMessage);

                // Deserialize the message using System.Text.Json
                var message = JsonSerializer.Deserialize<T>(receivedMessage);

                // Invoke the handler with the deserialized message
                handler(message);
            };

            _channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }

    }
}
