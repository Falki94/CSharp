using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebProjektCSClient.Models;

namespace WebProjektCSClient.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ProduktsView()
        {
            IEnumerable<Produkt> produkts = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:50596/api/");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("Produkt");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsStringAsync();
                    produkts = JsonConvert.DeserializeObject<IList<Produkt>>(readTask.Result);

                    //produkts = readTask.Result;
                }
                else
                {
                    //Error response received   
                    produkts = Enumerable.Empty<Produkt>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(produkts);
        }   
    }
}