using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using TMS.Client.HttpClientClasses;
using TMS.Client.Models;
using TMS.ClientSide.Models;

namespace TMS.Client.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee

        [HttpGet]
        public ActionResult CreateTravelRequest()
        {
            TravelDetails td = new TravelDetails();
            td.EmployeeId =Convert.ToInt32(Session["Username"]);

            return View(td);
        }

        [HttpPost]

        public ActionResult CreateTravelRequest(TravelDetails t)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            t.EmployeeId = Convert.ToInt32(Session["Username"]);

            HttpResponseMessage response = td.AddTravelRequest(Session["Access_Token"].ToString(), t);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.Content.ToString());

            }

            return Content(response.ReasonPhrase);
        }

        public ActionResult AllTravelRequest()
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }

            HttpResponseMessage response = td.GetTravelRequestsOfEmployee(Session["Access_Token"].ToString(),Convert.ToInt32(Session["Username"]));


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.ReasonPhrase);

            }
            IEnumerable<TravelDetails> emp = response.Content.ReadAsAsync<TravelDetails[]>().Result;
            return View(emp);
        }

        [HttpGet]
        public ActionResult EditTravelDetail(int id)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpResponseMessage response = td.GetTravelRequest(Session["Access_Token"].ToString(), id);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.StatusCode.ToString());

            }
            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;
            
            return View(emp);
        }

        [HttpPost]
        public ActionResult EditTravelDetail(TravelDetails t)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            t.EmployeeId = Convert.ToInt32(Session["Username"]);
            
            HttpResponseMessage response = td.EditTravelRequest(Session["Access_Token"].ToString(), t.MRNumber, t);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.StatusCode.ToString());

            }
            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;
            return View(emp);

        }

        [HttpGet]
        public ActionResult AddExpenseDetail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExpenseDetail(ExpenseDetails expense)
        {
            ExpenseDetailHttpClient ed = new ExpenseDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpResponseMessage response = ed.AddExpenseRequest(Session["Access_Token"].ToString(), expense);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.ReasonPhrase);

            }

            return Content(response.ReasonPhrase);

        }

       

        public ActionResult AllExpenseRequest()
        {
            List<ExpenseAndTravel> et = new List<ExpenseAndTravel>();

            ExpenseDetailHttpClient ed = new ExpenseDetailHttpClient();
            TravelDetailHttpClient td = new TravelDetailHttpClient();


            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpResponseMessage response = ed.GetAllExpenseRequest(Session["Access_Token"].ToString());


            if (!response.IsSuccessStatusCode)
            {
                return View();
            }
            IEnumerable<ExpenseDetails> emp = response.Content.ReadAsAsync<ExpenseDetails[]>().Result;

            foreach (var ex in emp)
            {
                HttpResponseMessage response1 = td.GetTravelRequest(Session["Access_Token"].ToString(), ex.MRNumber);


                if (!response1.IsSuccessStatusCode)
                {
                    return View();
                }
                TravelDetails td1 = response1.Content.ReadAsAsync<TravelDetails>().Result;
                et.Add(new ExpenseAndTravel { EmployeeId = td1.EmployeeId, ExpenseReportId = ex.ExpenseReportId, ExpenseDate = ex.ExpenseDate, ExpenseStatus = ex.ExpenseStatus, ExpenseType = ex.ExpenseType, PaymentType = ex.PaymentType, AmountSpent = ex.AmountSpent, ReimbursementAccountNo = ex.ReimbursementAccountNo, MRNumber = ex.MRNumber });

            }
            return View(et);
        }

        [HttpGet]
        public ActionResult EditExpenseDetail(int id)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpResponseMessage response = td.GetTravelRequest(Session["Access_Token"].ToString(), id);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.StatusCode.ToString());

            }
            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;

            return View(emp);
        }

        [HttpPost]
        public ActionResult EditExpenseDetail(TravelDetails t)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            t.EmployeeId = Convert.ToInt32(Session["Username"]);

            HttpResponseMessage response = td.EditTravelRequest(Session["Access_Token"].ToString(), t.MRNumber, t);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.StatusCode.ToString());

            }
            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;
            return View(emp);

        }

        [HttpGet]
        public JsonResult GetMrNumbers()
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            

            HttpResponseMessage response = td.GetTravelRequestsOfEmployee(Session["Access_Token"].ToString(), Convert.ToInt32(Session["Username"]));


            if (!response.IsSuccessStatusCode)
            {
                return Json(0);

            }
            IEnumerable<TravelDetails> emp = response.Content.ReadAsAsync<TravelDetails[]>().Result;
            return Json(emp.Where(e=>e.Status== "Approved").ToList(), JsonRequestBehavior.AllowGet);
        }


    }
}