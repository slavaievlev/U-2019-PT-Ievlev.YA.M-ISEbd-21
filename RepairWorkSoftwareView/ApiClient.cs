using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace RepairWorkSoftwareView
{
    public class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient();

        public static void Connect()
        {
            Client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["IPAddress"]);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static T GetRequest<T>(string requestUrl)
        {
            var response = Client.GetAsync(requestUrl);
            if (response.Result.IsSuccessStatusCode)
            {
                return response.Result.Content.ReadAsAsync<T>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
        }

        public static U PostRequest<T, U>(string requestUrl, T model)
        {
            var response = Client.PostAsJsonAsync(requestUrl, model);
            if (response.Result.IsSuccessStatusCode)
            {
                if (typeof(U) == typeof(bool))
                {
                    return default(U);
                }

                return response.Result.Content.ReadAsAsync<U>().Result;
            }
            throw new Exception(response.Result.Content.ReadAsStringAsync().Result);
        }
    }
}