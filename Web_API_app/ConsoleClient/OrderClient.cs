using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_API_app.Models;

namespace ConsoleClient
{
    public class OrderClient
    {
        private const string path = @"https://localhost:44356/";
        
        public void GetOrders()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path + "/api/Order").Result;
                var res = response.Content.ReadAsStringAsync().Result;
                var rez2 = response.Content.ReadAsAsync<List<Order>>().Result;
                foreach (Order p in rez2)
                    Console.WriteLine($":  {p.Date}    Good Name:  {p.GoodName}   Good count :  {p.Count}   Email:  {p.Email}");
            }
        }

        public void GetOrder()
        {
            using (var client = new HttpClient())
            {
                int id = int.Parse(Console.ReadLine());
                var response = client.GetAsync(path + $"/api/Order/{id}").Result;
                var res = response.Content.ReadAsStringAsync().Result;

                var rez2 = response.Content.ReadAsAsync<List<Order>>().Result;
                foreach (Order p in rez2)
                    Console.WriteLine($":  {p.Date}    Good Name:  {p.GoodName}   Good count :  {p.Count}   Email:  {p.Email}");
            }
        }

        public void CreateOrder()
        {
            using (var client = new HttpClient())
            {
                Order order = new Order() { };
                var response = client.PostAsJsonAsync(path + "/api/Order", order).Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }
        }

        public void DeleteGood()
        {
            using (var client = new HttpClient())
            {
                int id = int.Parse(Console.ReadLine());
                var response = client.DeleteAsync(path + $"/api/Order/{id}").Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }

        }
    }
}
