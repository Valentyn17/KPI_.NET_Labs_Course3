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
                    Console.WriteLine($" ID : {p.Id}   Date :  {p.Date}    Good Name:  {p.GoodName}   Good count :  {p.Count}   Email:  {p.Email}");
            }
        }

        public void GetOrder()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Write id of element:");
                int id = int.Parse(Console.ReadLine());
                var response = client.GetAsync(path + $"/api/Order/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Element with such id doesn't exist");
                }
                else
                {
                    var res = response.Content.ReadAsStringAsync().Result;

                    var rez2 = response.Content.ReadAsAsync<Order>().Result;
                        Console.WriteLine($"Id  {rez2.Id}   Date  {rez2.Date}    Good Name:  {rez2.GoodName}   Good count :  {rez2.Count}   Email:  {rez2.Email}");
                }
            }
        }

        public void CreateOrder()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Creating order:");
                Console.WriteLine("Choose good id");
                int a = int.Parse(Console.ReadLine());
                Console.WriteLine("Write good count");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Write Email");
                string e = Console.ReadLine();
                Order order = new Order() { Email = e, Count=b, GoodId=a};
                var response = client.PostAsJsonAsync(path + "/api/Order", order).Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Model is not valid");
                }
                else
                {
                    var statusCode = response.StatusCode.ToString();
                    Console.WriteLine(statusCode.ToString());
                }
            }
        }

        public void DeleteOrder()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Write id of item whixh you want to delete:");
                int id = int.Parse(Console.ReadLine());
                var response = client.DeleteAsync(path + $"/api/Order/{id}").Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }

        }
    }
}
