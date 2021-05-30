using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace TMS.Client.HttpClientClasses
{
    public class ExpenseAccepted
    {
        string baseaddress = "https://localhost:44397/api/ExpenseAccepted/";

        public HttpResponseMessage GetAllExpenseAccepted(string token)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("getea").Result;

            return response;
        }

        public HttpResponseMessage GetExpenseAccepted(string token, int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("getea/" + id).Result;

            return response;
        }

       
    }
}