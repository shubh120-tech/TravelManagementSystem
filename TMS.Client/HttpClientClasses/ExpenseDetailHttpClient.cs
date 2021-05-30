using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TMS.ClientSide.Models;

namespace TMS.Client.HttpClientClasses
{
    public class ExpenseDetailHttpClient
    {
        string baseaddress = "https://localhost:44397/api/Expensedetail/";

        public HttpResponseMessage GetAllExpenseRequest(string token)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("geted").Result;

            return response;
        }

        public HttpResponseMessage GetExpenseRequest(string token, int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("geted/" + id).Result;

            return response;
        }

        public HttpResponseMessage EditExpenseRequest(string token, int id,ExpenseDetails ed)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.PutAsJsonAsync("puted/" + id, ed).Result;

            return response;
        }

        public HttpResponseMessage AddExpenseRequest(string token, ExpenseDetails td)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.PostAsJsonAsync("posted/", td).Result;

            return response;
        }

        public HttpResponseMessage DeleteExpenseRequest(string token, int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.DeleteAsync("deleteed/" + id).Result;

            return response;
        }
    }
}