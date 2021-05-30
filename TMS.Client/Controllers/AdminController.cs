using System.Collections.Generic;
using System.Net.Http;
using System.Web.Mvc;
using TMS.Client.HttpClientClasses;
using TMS.Client.Models;
using TMS.ClientSide.Models;

namespace TMS.Client.Controllers
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Employees()
        {
            EmployeeMasterHttpClient employee = new EmployeeMasterHttpClient();

            if (Session["Access_Token"] == null)
            {
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


        public ActionResult TravelDetails()
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();
            if (Session["Access_Token"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            HttpResponseMessage response = td.GetAllTravelRequest(Session["Access_Token"].ToString());


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
            HttpResponseMessage response = td.EditTravelRequest(Session["Access_Token"].ToString(), t.MRNumber, t);


            if (!response.IsSuccessStatusCode)
            {
                return Content(response.StatusCode.ToString());

            }
            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;
            return View(emp);

        }

        public ActionResult ExpenseDetails()
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

        [HttpPost]
        public void ApproveTravelRequest(int id)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();

            HttpResponseMessage response = td.GetTravelRequest(Session["Access_Token"].ToString(), id);

            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;

            emp.Status = "Approved";

            HttpResponseMessage response1 = td.EditTravelRequest(Session["Access_Token"].ToString(), id, emp);


        }
        [HttpPost]
        public void RejectTravelRequest(int id)
        {
            TravelDetailHttpClient td = new TravelDetailHttpClient();

            HttpResponseMessage response = td.GetTravelRequest(Session["Access_Token"].ToString(), id);

            TravelDetails emp = response.Content.ReadAsAsync<TravelDetails>().Result;

            emp.Status = "Reject";

            HttpResponseMessage response1 = td.EditTravelRequest(Session["Access_Token"].ToString(), id, emp);


        }

        [HttpPost]
        public void ApproveExpenseRequest(int id)
        {
            ExpenseDetailHttpClient ed = new ExpenseDetailHttpClient();


            HttpResponseMessage response = ed.GetExpenseRequest(Session["Access_Token"].ToString(), id);

            ExpenseDetails emp = response.Content.ReadAsAsync<ExpenseDetails>().Result;

            emp.ExpenseStatus = "Approved";

            HttpResponseMessage response1 = ed.EditExpenseRequest(Session["Access_Token"].ToString(), id, emp);


        }
        [HttpPost]
        public void RejectExpenseRequest(int id)
        {
            ExpenseDetailHttpClient ed = new ExpenseDetailHttpClient();


            HttpResponseMessage response = ed.GetExpenseRequest(Session["Access_Token"].ToString(), id);

            ExpenseDetails emp = response.Content.ReadAsAsync<ExpenseDetails>().Result;

            emp.ExpenseStatus = "Reject";

            HttpResponseMessage response1 = ed.EditExpenseRequest(Session["Access_Token"].ToString(), id, emp);


        }







    }
}