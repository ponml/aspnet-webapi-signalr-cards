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
using game_app_server.Resources;

namespace game_app_server.Hubs
{
    public class LobbyHub : Hub
    {
        private Task<object> MakeLobby(string lobbyName, string groupId)
        {
            var newLobby = new Lobby
            {
                Name = lobbyName,
                GroupId = groupId
            };
            
            return HttpHelper.Post<Lobby>(string.Format("api/Lobbies", newLobby));
        }

        private void DeleteLobby(int groupId)
        {
            //maybe get the lobby first, so can delete by ID?
            HttpHelper.Delete(string.Format("api/Lobbies?groupId={0}", groupId));
        }


        public override Task OnDisconnected(bool stopCalled)
        {
            //if this lobbygroup is empty, we should delete the lobby from the DB

            Groups.Remove(Context.ConnectionId, )
            return base.OnDisconnected(stopCalled);
        }

        public async Task<object> JoinLobby(Guid connectionId, string lobbyName)
        {
         
            //  notes OCT 2
            // need to clean up the make/delete lobby logic, need to find out if Groups have an id, or should we just use the groupName for Lobby.GroupId;
            // do groups automatically get deleted if all people removed from them?
            // how do we figure out we're the last person in this lobby?
            // maybe it'd be delete the Player, and then check after if any Player exists without that LobbyId?
            // maybe we can see if that Group has any connectionIds in it, and if not, delete the lobby.

            var lobby = await HttpHelper.Get(string.Format("api/Lobbies?name={0}", lobbyName));
            //Clients.Caller.joinedLobby(JsonConvert.SerializeObject(lob));
            if(lobby == null)
            {
                await Groups.Add(Context.ConnectionId, lobbyName);
                lobby = await MakeLobby();
            }
            return lobby;
        }
    }
}