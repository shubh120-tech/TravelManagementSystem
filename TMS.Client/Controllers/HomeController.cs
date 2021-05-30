using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

using System.Web.Mvc;
using TMS.Client.HttpClientClasses;
using TMS.Client.Models;

namespace TMS.Client.Controllers
{

    public class HomeController : Controller
    {

        public ActionResult Index()
        {

            //string baseaddress = "https://localhost:44397/api/employeemaster/";
            //HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri(baseaddress);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ////GET Method  
            //HttpResponseMessage response =  client.GetAsync("getem").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    IEnumerable<EmployeeMaster> emp = response.Content.ReadAsAsync<EmployeeMaster[]>().Result;
            //    return View(emp);
            //}
            EmployeeMasterHttpClient employee = new EmployeeMasterHttpClient();
            if (Session["Access_Token"] == null) {
                return RedirectToAction("Login", "Home"); 
            }
            HttpResponseMessage response = employee.GetAllEmployee(Session["Access_Token"].ToString());

        
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }
            IEnumerable<EmployeeMaster> emp = response.Content.ReadAsAsync<EmployeeMaster[]>().Result;
            return View(emp);

            
        }
        [HttpGet]
        public ActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterBindingModel register)
        {
            string baseaddress = "https://localhost:44397/api/account/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //GET Method  
            HttpResponseMessage response = client.PostAsJsonAsync("register",register).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "Home");

            }
           
            
                return Content(response.StatusCode.ToString());
            
           
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login login)
        {
            Token token = new Token();
            string token1, token2;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44397");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var formContent = new FormUrlEncodedContent(new[]
                {
             new KeyValuePair<string, string>("grant_type", "password"),
             new KeyValuePair<string, string>("username", login.username),
             new KeyValuePair<string, string>("password", login.password),
         });
                //send request
                HttpResponseMessage responseMessage = client.PostAsync("/Token", formContent).Result;
                //get access token from response body
                token = responseMessage.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;
                Session["Access_Token"] = token.AccessToken;
                Session["Username"] = token.userName;
                token1 = token.AccessToken;
                if (Session["Access_Token"] != null)
                {
                    using (var client1 = new HttpClient())
                    {
                        using (var context = new ApplicationDbContext())
                        {
                            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                            var s = UserManager.FindAsync(login.username, login.password);
                            if (s != null)
                            {
                                // await SignInAsync(s, isPersistent: false, rememberBrowser: false);
                                // s.Result.Roles.FirstOrDefault();
                                var getRoleId = context.Roles.Where(r => r.Name == "Admin").Select(m => m.Id).SingleOrDefault();
                                var fetch = context.Users.Where(u => u.Roles.Any(r => r.RoleId.ToString() == getRoleId)).ToList();
                                if (fetch.Select(e => e.Id).FirstOrDefault() == s.Result.Id)
                                {
                                    return RedirectToAction("Employees", "Admin");
                                }
                                return RedirectToAction("CreateTravelRequest", "Employee");



                            }
                        }

                    }
                }
                return View();
                
            }
            
            return View();
        }





        public ActionResult GetToken()
        {
            return View();
        }
          

        
    }
}
