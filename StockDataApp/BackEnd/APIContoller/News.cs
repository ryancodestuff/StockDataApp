using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using RestSharp;

namespace StockDataApp.BackEnd.APIContoller
{
    public class News
    {
        public string data()
        {
            var client = new RestClient("https://reuters-business-and-financial-news.p.rapidapi.com/article-date/2021-04-01");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-RapidAPI-Key", "8f68560f8emsh25a5e25140bb2b3p18ac96jsn87c8bc5bcc71");
            request.AddHeader("X-RapidAPI-Host", "reuters-business-and-financial-news.p.rapidapi.com");
            IRestResponse response = client.Execute(request);
            string news = response.Content;
            return news;
        }
    }
}
