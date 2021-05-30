using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using TMS.ClientSide.Models;

namespace TMS.Client.HttpClientClasses
{
    public class TravelDetailHttpClient
    {
        string baseaddress = "https://localhost:44397/api/traveldetail/";

        public HttpResponseMessage GetAllTravelRequest(string token)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("gettd").Result;

            return response;
        }

        public HttpResponseMessage GetTravelRequest(string token, int id)
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("gettd/" + id).Result;

            return response;
        }

        public HttpResponseMessage GetTravelRequestsOfEmployee(string token, int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.GetAsync("gettdbyemployeeid/" + id).Result;

            return response;
        }

        public HttpResponseMessage EditTravelRequest(string token, int id, TravelDetails td)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.PutAsJsonAsync("puttd/" + id, td).Result;

            return response;
        }

        public HttpResponseMessage AddTravelRequest(string token, TravelDetails td)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.PostAsJsonAsync("posttd/", td).Result;

            return response;
        }

        public HttpResponseMessage DeleteTravelRequest(string token, int id)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseaddress);
            client.DefaultRequestHeaders.Accept.Clear();

            // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
            //GET Method  
            HttpResponseMessage response = client.DeleteAsync("deletetd/" + id).Result;

            return response;
        }
    }
}