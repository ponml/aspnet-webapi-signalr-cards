using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace game_app_server.ApiContext
{
    public sealed class ApiHttpClient
    {
        private static volatile ApiClient instance;
        private static object syncRoot = new Object();

        private ApiHttpClient() { }

        public static ApiClient Client
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ApiClient();
                    }
                }

                return instance;
            }
        }
    }

    public class ApiClient
    {
        public static string REST_SERVER = "http://localhost:62549/";
        private static HttpClient httpClient;
        public ApiClient()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(REST_SERVER);
        }
        //Hosted web API REST Service base url  
        public async Task<TResponse> GetAsync<TResponse>(string url)
            where TResponse : class
        {
            var uri = url;
            //Passing service base url  
            httpClient.DefaultRequestHeaders.Clear();
            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage res = await httpClient.GetAsync(uri);

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                var responseString = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TResponse>(responseString);
                return result;
            }
            else
            {
                Console.WriteLine(string.Format("HTTP call to {0} unsuccessful: {1}", uri, res.Content));
                return default(TResponse);
            }
        }

        public async Task<TResponse> PostAsync<TResponse>(string url, object data)
            where TResponse : class
        {
            //Passing service base url  
            var uri = url;

            httpClient.DefaultRequestHeaders.Clear();
            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonPayload = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage res = await httpClient.PostAsync(uri, httpContent);

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var responseString = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TResponse>(responseString);
                return result;
            }
            else
            {
                Console.WriteLine(string.Format("HTTP call to {0} unsuccessful: {1}", uri, res.Content));
                return default(TResponse);
            }
        }

        public async Task<TResponse> PutAsync<TResponse>(string url, object data)
                    where TResponse : class
        {
            //Passing service base url  
            var uri = url;

            httpClient.DefaultRequestHeaders.Clear();
            //Define request data format  
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var jsonPayload = JsonConvert.SerializeObject(data);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            HttpResponseMessage res = await httpClient.PutAsync(uri, httpContent);

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var responseString = res.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<TResponse>(responseString);
                return result;
            }
            else
            {
                Console.WriteLine(string.Format("HTTP call to {0} unsuccessful: {1}", uri, res.Content));
                return default(TResponse);
            }
        }
    }
}