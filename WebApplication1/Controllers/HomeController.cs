using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            IEnumerable<MemberViewModel> members = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/api/Swagger");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("employee");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MemberViewModel>>();
                    readTask.Wait();

                    members = readTask.Result;
                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<MemberViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(members);
        }
        public ActionResult GetMembers()
        {
            IEnumerable<MemberViewModel> members = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/api");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("employee");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MemberViewModel>>();
                    readTask.Wait();

                    members = readTask.Result;
                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<MemberViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(members);
        }
        //var responseTask = client.GetAsync("member");

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
        public ActionResult Delete()
        {
            IEnumerable<MemberViewModel> members = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44341/api/swagger");

                //Called Member default GET All records  
                //GetAsync to send a GET request   
                // PutAsync to send a PUT request  
                var responseTask = client.GetAsync("employee");
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<MemberViewModel>>();
                    readTask.Wait();

                    members = readTask.Result;
                }
                else
                {
                    //Error response received   
                    members = Enumerable.Empty<MemberViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error try after some time.");
                }
            }
            return View(members);
        }
    }
}