using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BethanysPieShopHRM.UI.Services
{
    public class RecruitingClient
    {
        public HttpClient Client { get; private set; }

        public RecruitingClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44323/");
            Client = httpClient;
        }
    }
}
