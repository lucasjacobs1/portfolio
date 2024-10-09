﻿
namespace BusinessLayer.Models
{
    public class RabbitMessage<T>
    {
        public string ExchangeName { get; set; } = "identity_data_service";
        public string RoutingKey { get; set; } = string.Empty;
        public T Data { get; set; }
    }
}
