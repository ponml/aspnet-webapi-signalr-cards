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
using game_app_server;
using Newtonsoft.Json;
using game_app_server.ApiContext;
using Microsoft.AspNet.SignalR.Hubs;

namespace game_app_server.Hubs
{
    public class LobbyHub : Hub
    {
        private Task<Lobby> GetLobby(string lobbyName)
        {
            return ApiHttpClient.Client.GetAsync<Lobby>(string.Format("api/Lobbies?name={0}", lobbyName));
        }

        private Task<Card[]> GetCards()
        {
            return ApiHttpClient.Client.GetAsync<Card[]>(string.Format("api/cards"));
        }

        [HubMethodName("JoinLobby")]
        public async Task<object> JoinLobby(Guid connectionId, string lobbyName)
        {
            //search db for any lobbys with this name -> make http request to lobby controller in REST server
            //if result-> use that data to join the proper group in this hub
            //else -> create a new Lobby.cs, Create a new Group for this hub

            //Create a new Player.cs

            // Call the addNewMessageToPage method to update clients.
            //var potentialLobbies = SendGetRequest(string.Format("http://{0}/api/lobbies?name={1}", REST_SERVER, lobbyName));

            var cards = await GetCards();

            Lobby requestedLobby = await GetLobby(lobbyName);
            
            if (requestedLobby == null)
            {
                requestedLobby = new Lobby
                {
                    Name = lobbyName,
                };
                var newLobby = await ApiHttpClient.Client.PostAsync<Lobby>("api/Lobbies", requestedLobby);
                requestedLobby = newLobby;
            }

            

            return new
            {
                lobby = requestedLobby,
                cards = cards
            };
        }
    }
}