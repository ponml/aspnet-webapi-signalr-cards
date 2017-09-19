using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace game_app_server.Hubs
{
    public class LobbyHub : Hub
    {
        public static string REST_SERVER = "localhost:62549";
        public static WebResponse SendPostRequest(string data, string url)
        {

            //Data parameter Example
            //string data = "name=" + value

            WebRequest httpRequest = WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.ContentLength = data.Length;

            var streamWriter = new StreamWriter(httpRequest.GetRequestStream());
            streamWriter.Write(data);
            streamWriter.Close();

            return httpRequest.GetResponse();
        }

        public static WebResponse SendGetRequest(string url)
        {

            WebRequest httpRequest = WebRequest.Create(url);
            httpRequest.Method = "GET";

            return httpRequest.GetResponse();
        }

        public void JoinLobby(Guid connectionId, string lobbyName)
        {
            //search db for any lobbys with this name -> make http request to lobby controller in REST server
            //if result-> use that data to join the proper group in this hub
            //else -> create a new Lobby.cs, Create a new Group for this hub

            //Create a new Player.cs

            // Call the addNewMessageToPage method to update clients.
            var potentialLobbies = SendGetRequest(string.Format("http://{0}/api/lobbies?name={1}", REST_SERVER, lobbyName));
            using (var response = potentialLobbies.GetResponseStream())
            {

            }
                Console.WriteLine("JOINED LOBBY: {0}", lobbyName);
        }
    }
}