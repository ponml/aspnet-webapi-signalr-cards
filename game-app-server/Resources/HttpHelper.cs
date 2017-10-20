using aspnet_webapi_signalr_cards.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace game_app_server.Resources
{
    public static class HttpHelper
    {
        public static string REST_SERVER = "http://localhost:62549";
        //could maybe have an out variable for "success" or not
        //Hosted web API REST Service base url
        public static async Task<object> Get(string url)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(REST_SERVER);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync(url);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;
                    var deserialized = JsonConvert.DeserializeObject(response);
                    return deserialized;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                }
                else
                {
                    return Res.Content;
                }
            }
        }

        public static async void Delete(string url)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(REST_SERVER);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.DeleteAsync(url);
            }
        }

        public static async Task<object> Post<T>(string url, T payload)
        {
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(REST_SERVER);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonPayload = JsonConvert.SerializeObject(payload);

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.PostAsJsonAsync(url, payload);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var response = Res.Content.ReadAsStringAsync().Result;
                    return response;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                }
                else
                {
                    return Res.Content;
                }
            }
        }
    }
}