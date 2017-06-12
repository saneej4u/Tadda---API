using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace Tadda.Dashboard.Web.Helper
{
    public class TaddaApiClient : ITaddaApiClient
    {
        private const string BaseUri = "http://localhost/Tadda.WebApi/";
        public async Task<HttpResponseMessage> GetFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseUri);
                using (var content = new FormUrlEncodedContent(values))
                {
                    var query = await content.ReadAsStringAsync();
                    var requestUriWithQuery = string.Concat(requestUri, "?", query);
                    var response = await client.GetAsync(requestUriWithQuery);
                    return response;
                }
            }
        }

        public async Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsJsonAsync(requestUri, content);
                return response;
            }

        }
    }
}