using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace game_app_server.Hubs
{
    public class LobbyHub : Hub
    {
        public void JoinLobby(Guid connectionId, string lobbyName)
        {
            // Call the addNewMessageToPage method to update clients.
            Console.WriteLine("JOINED LOBBY: {0}", lobbyName);
        }
    }
}