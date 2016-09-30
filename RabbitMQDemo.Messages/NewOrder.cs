using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemo.Messages
{
    public class NewOrder
    {
        public string CustomerName { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}
