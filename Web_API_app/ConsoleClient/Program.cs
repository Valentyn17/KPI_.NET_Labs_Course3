using ConsoleClient.GoodMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_API_app.Models;

namespace ConsoleClient
{
    class Program
    {

        public const string path = @"https://localhost:44356/";
        static void Main(string[] args)
        {
            GoodClient menu = new GoodClient();
            OrderClient client = new OrderClient();
            Console.WriteLine("It's storage app");
            while (true)
            {

                Console.WriteLine("Select action:");
                Console.WriteLine("1 - Get all goods\n" +
                    "2 - Get specific good\n" +
                    "3 - Create good\n" +
                    "4 - Delete Good\n" +
                    "5 - Get all orders\n" +
                    "6 - Get specific order\n" +
                    "7 - Create Order\n" +
                    "8 - Delete Order\n");
                int a = int.Parse(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        {
                            menu.GetGoods();
                            break;
                        }
                    case 2:
                        {
                            menu.GetGood();
                            break;
                        }
                    case 3:
                        {
                            menu.CreateGood();
                            break;
                        }
                    case 4:
                        {
                            menu.DeleteGood();
                            break;
                        }
                    case 5:
                        {
                            client.GetOrders();
                            break;
                        }
                    case 6:
                        {
                            client.GetOrder();
                            break;
                        }
                    case 7:
                        {
                            client.CreateOrder();
                            break;
                        }
                    case 8:
                        {
                            client.DeleteOrder();
                            break;
                        }
                   
                    default:
                        break;
                }
            }
        }
    }
}
