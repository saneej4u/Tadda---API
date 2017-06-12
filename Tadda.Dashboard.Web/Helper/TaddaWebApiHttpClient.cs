using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Web;
using Thinktecture.IdentityModel.Client;

namespace Tadda.Dashboard.Web.Helper
{
    public static class TaddaWebApiHttpClient
    {
        public const string TADDA_WEB_API_URL = "http://localhost/Tadda.WebApi/";
        public static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TADDA_WEB_API_URL);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}