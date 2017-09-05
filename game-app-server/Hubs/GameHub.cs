using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using game_app_server.Models;

namespace game_app_server.Hubs
{
    public class GameHub : Hub
    {
        public void PlayerJoined(string name)
        {
            
            Clients.All.broadcastMessage(name, "joined the lobby");
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}