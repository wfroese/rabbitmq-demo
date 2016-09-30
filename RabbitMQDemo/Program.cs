using EasyNetQ;
using RabbitMQDemo.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string order = null;

            Console.WriteLine("Welcome to the RabbitMQ Store front. Enter your order, or \"quit\" to close the store front. ");

            using (var bus = RabbitHutch.CreateBus("host=localhost"))
            {
                while ((order = Console.ReadLine()) != "quit")
                {

                    Console.WriteLine("Thank you for your order!");

                    var newOrderMessage = new NewOrder
                    {
                        CustomerName = order.Split(':').Select(x => x.Trim()).ToList()[0],
                        Product = order.Split(':').Select(x => x.Trim()).ToList()[1],
                        Quantity = Convert.ToInt32(order.Split(':').Select(x => x.Trim()).ToList()[2])
                    };

                    bus.Publish(newOrderMessage);
                }
            }
        }
    }
}
