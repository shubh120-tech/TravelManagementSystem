using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TMS.Client.Models;
using TMS.ClientSide.Models;

namespace TMS.Client.HttpClientClasses
{
    public class MergeTableData
    {
        //string baseaddresstravel = "https://localhost:44397/api/traveldetail/";

        //public IEnumerable<ExpenseAndTravel> ExpenseTravelData(string token)
        //{
        //    IEnumerable<TravelDetails> td = new List<TravelDetails>();
        //    IEnumerable<ExpenseDetails> ed = new List<ExpenseDetails>();
        //    ExpenseAndTravel ET = new ExpenseAndTravel();
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(baseaddresstravel);
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    // client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
        //    //GET Method  
        //    HttpResponseMessage response = client.GetAsync("gettd").Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        td = response.Content.ReadAsAsync<TravelDetails[]>().Result;
        //    }

        //    using(var httpclient = new HttpClient())
        //    {

        //    }

        //    return response;
        
    }
}