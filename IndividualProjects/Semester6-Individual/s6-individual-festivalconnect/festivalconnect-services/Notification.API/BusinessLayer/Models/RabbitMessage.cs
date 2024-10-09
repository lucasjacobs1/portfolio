using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class RabbitMessage<T>
    {
        public string ExchangeName { get; set; } = "notification_data_service";
        public string RoutingKey { get; set; } = string.Empty;
        public T Data { get; set; }
    }

}
