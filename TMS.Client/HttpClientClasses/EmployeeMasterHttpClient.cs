using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using TMS.Client.Models;

namespace TMS.Client.HttpClientClasses
{
    public class EmployeeMasterHttpClient
    {
        string baseaddress = "https://localhost:44397/api/employeemaster/";

        public HttpResponseMessage GetAllEmployee(string token)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}",token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("getem").Result;
            
            return response;
        }

        public HttpResponseMessage GetEmployee(string token,int id)
        {
            IEnumerable<EmployeeMaster> emp = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("getem/"+id).Result;

            return response;
        }

        public HttpResponseMessage EditEmployeeDetails(string token, int id,EmployeeMaster emp)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.PutAsJsonAsync("putem/" + id,emp).Result;

            return response;
        }

       public HttpResponseMessage AddEmployee(string token, EmployeeMaster emp)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.PostAsJsonAsync("postem/", emp).Result;

            return response;
        }

        public HttpResponseMessage DeleteEmployee(string token,int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.DeleteAsync("deleteem/"+id).Result;

            return response;
        }






    }
}