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
        
        public void GetGoods()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path + "/api/Good").Result;
                var res = response.Content.ReadAsStringAsync().Result;
                var rez2 = response.Content.ReadAsAsync<List<Good>>().Result;
                foreach (Good p in rez2)
                    Console.WriteLine($"ID {p.Id}    Product Name:  {p.Name}    Price:  {p.Price}   Description :  {p.Descr}   Count:  {p.Count}");
            }
        }

        public void GetGood()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Write id of element which you  want to get");
                int id = int.Parse(Console.ReadLine());
                var response = client.GetAsync(path + $"/api/Good/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Element with such id not exists");
                }
                else
                {
                    var res = response.Content.ReadAsStringAsync().Result;

                    var rez2 = response.Content.ReadAsAsync<Good>().Result;
                    Console.WriteLine($"ID {rez2.Id}   Product Name:  {rez2.Name}    Price:  {rez2.Price}   Description :  {rez2.Descr}   Count:  {rez2.Count}");
                }
            }
        }

        public void CreateGood()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Creating good:");
                Console.WriteLine("Write good name");
                string a = Console.ReadLine();
                Console.WriteLine("Write good count");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("Write good price");
                int c = int.Parse(Console.ReadLine());
                Console.WriteLine("Write Description");
                string e = Console.ReadLine();
                Good good = new Good() {  Name =a, Price =c, Count =b, Descr =e };
                var response = client.PostAsJsonAsync(path + "/api/Good", good).Result;
                var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
            }
        }

        public void DeleteGood()
        {
            using (var client = new HttpClient())
            {
                Console.WriteLine("Write id of element which you want to delete");
                int id= int.Parse(Console.ReadLine());
                var response = client.DeleteAsync(path + $"/api/Good/{id}").Result;
                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Ivalid id");
                }
                else { 
                    var statusCode = response.StatusCode.ToString();
                Console.WriteLine(statusCode.ToString());
                }
                
            }

        }

    }
}
                

                   

            

                   

        

       

        

        
