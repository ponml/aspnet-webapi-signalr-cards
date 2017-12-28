﻿using System;
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

namespace game_app_server.Hubs
{
    public class LobbyHub : Hub
    {
        public Task<Lobby> GetLobby(string lobbyName)
        {
            var apiHttpClient = ApiHttpClient.Client;
            return apiHttpClient.GetAsync<Lobby>(string.Format("api/Lobbies?name={0}", lobbyName));
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