using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using aspnet_webapi_signalr_cards.Models;

namespace game_app_server.Hubs
{
    public class GameHub : Hub
    {
        //public void PlayerJoined(Player player)
        //{
            
        //    Clients.All.broadcastMessage(player.Name, "joined the lobby");
        //}

        //public void Send(string name, string message)
        //{
        //    // Call the addNewMessageToPage method to update clients.
        //    Clients.All.broadcastMessage(name, message);
        //}
    }
}