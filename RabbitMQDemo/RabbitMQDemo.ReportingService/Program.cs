using RabbitMQDemo.Messages;
using System;
using EasyNetQ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemo.ReportingService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                bus.Subscribe<NewOrder>("1", HandleNewOrder);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }
        }

        private static void HandleNewOrder(NewOrder order)
        {
            Console.WriteLine("Reporting service received a new order: " + order.CustomerName);
        }
    }
}
