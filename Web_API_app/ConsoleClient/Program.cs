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
            client.GetOrders();

        }
    }
}
