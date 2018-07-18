using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using HackerNewsProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HackerNewsProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
           

            return View();
        }
        
        public void  GettingFiles()
        {
            string[] allJsonFiles = new string[] {
                "https://hacker-news.firebaseio.com/v0/item/8863.json?print=pretty",
                "https://hacker-news.firebaseio.com/v0/item/121003.json?print=pretty" };

            //foreach (var x in allJsonFiles)
            //{
            //    GetAllData(x);
            //}
            //return "DONE"; 
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }

        [Route("api/GetDataJson")]
        public List<ObjectModel> GetAllData()
        {
            List<ObjectModel> list = new List<ObjectModel>();
            string[] allJsonFiles = new string[] {
                "https://hacker-news.firebaseio.com/v0/item/8863.json?print=pretty",
                "https://hacker-news.firebaseio.com/v0/item/121003.json?print=pretty",
            "https://hacker-news.firebaseio.com/v0/item/192327.json?print=pretty",
            "https://hacker-news.firebaseio.com/v0/item/126809.json?print=pretty",
            };
            string URL = "";
            foreach (var x in allJsonFiles)
            {
                URL = x;




                var json = JsonConvert.SerializeObject(new
                {
                    title = "Title",
                    by = "Author"
                });


                try
                {

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri(URL);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response = client.GetAsync(URL).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var data = response.Content.ReadAsAsync<ObjectModel>().Result;
                        list.Add(data);


                    }
                    else
                    {
                        Console.WriteLine("Something went wrong");
                    }

                    client.Dispose();

                }
                catch (Exception ex)
                {
                    var error = ex.ToString();
                }
            }
            return list;

        }

    }
}
