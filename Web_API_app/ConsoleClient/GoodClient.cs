using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web_API_app.Models;

namespace ConsoleClient.GoodMenu
{

    public class GoodClient
    {
        private const string path = @"https://localhost:44356/";
        Good good = new Good() { Id = 300, Name = "NewName", Price = 5.7M, Count = 20, Descr = "Tasty fruit" };
        public void GetGoods()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path + "/api/Good").Result;
                var res = response.Content.ReadAsStringAsync().Result;
                var rez2 = response.Content.ReadAsAsync<List<Good>>().Result;
                foreach (Good p in rez2)
                    Console.WriteLine($"Product Name:  {p.Name}    Price:  {p.Price}   Description :  {p.Descr}   Count:  {p.Count}");
            }
        }

        public void GetGood()
        {
            using (var client = new HttpClient())
            {
                int id = int.Parse(Console.ReadLine());
                var response = client.GetAsync(path + $"/api/Good/{id}").Result;
                var res = response.Content.ReadAsStringAsync().Result;

                var rez2 = response.Content.ReadAsAsync<List<Good>>().Result;
                foreach (Good p in rez2)
                    Console.WriteLine($"Product Name:  {p.Name}    Price:  {p.Price}   Description :  {p.Descr}   Count:  {p.Count}");
            }
        }

        public void CreateGood()
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync(path + "/api/Good", good).Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }
        }

        public void DeleteGood()
        {
            using (var client = new HttpClient())
            {
                int id= int.Parse(Console.ReadLine());
                var response = client.DeleteAsync(path + $"/api/Good/{id}").Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }

        }

    }
}
                

                   

            

                   

        

       

        

        
