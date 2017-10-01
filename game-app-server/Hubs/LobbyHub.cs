using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using aspnet_webapi_signalr_cards.Models;
using Newtonsoft.Json;

namespace game_app_server.Hubs
{
    public class LobbyHub : Hub
    {
        public static string REST_SERVER = "http://localhost:62549";

        //Hosted web API REST Service base url  
        public async Task<object> Get(string url)
        {
            var lobbies = new List<Lobby>();
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
                    return response;
                    //Deserializing the response recieved from web api and storing into the Employee list  
                }
                else
                {
                    return Res.Content;
                }
            }
        }

        public Task<object> GetLobby(string lobbyName)
        {
            return Get(string.Format("api/Lobbies?name={0}", lobbyName));
        }

        public async Task<object> JoinLobby(Guid connectionId, string lobbyName)
        {
            //search db for any lobbys with this name -> make http request to lobby controller in REST server
            //if result-> use that data to join the proper group in this hub
            //else -> create a new Lobby.cs, Create a new Group for this hub

            //Create a new Player.cs

            // Call the addNewMessageToPage method to update clients.
            //var potentialLobbies = SendGetRequest(string.Format("http://{0}/api/lobbies?name={1}", REST_SERVER, lobbyName));
            //using (var response = potentialLobbies.GetResponseStream())
            //{

            //}
            var getLob = await GetLobby(lobbyName);
            var lob = getLob;
            //Clients.Caller.joinedLobby(JsonConvert.SerializeObject(lob));
            return lob;
        }
    }
}