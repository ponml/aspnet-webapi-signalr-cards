using aspnet_webapi_signalr_cards.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace aspnet_webapi_signalr_cards.Controllers
{
    public class LobbiesController : ApiController
    {
        public object[] GetAllLobbies()
        {
            using (var dbContext = DbAppContextManager.GetContext())
            {
                var lobbyQuery =
                    from lobby in dbContext.Lobbies
                    select lobby;

                var result = lobbyQuery.ToArray();
                return result;
            }
        }

        public IHttpActionResult GetLobby(int id)
        {
            using (var dbContext = DbAppContextManager.GetContext())
            {
                var lobbyQuery =
                    from lobby in dbContext.Lobbies
                    where lobby.Id == id
                    select lobby;

                var result = lobbyQuery.FirstOrDefault();

                return Ok(result);
            }
        }

        public IHttpActionResult GetLobby(string name)
        {
            using (var dbContext = DbAppContextManager.GetContext())
            {
                var lobbyQuery =
                    from lobby in dbContext.Lobbies
                    where lobby.Name == name
                    select lobby;

                var result = lobbyQuery.FirstOrDefault();
                return Ok(result);
            }
        }
        public IHttpActionResult Post([FromBody]Lobby lobby)
        {
            var newLobby = new Lobby
            {
                GameId = lobby.GameId,
                GroupId = lobby.GroupId,
                Name = lobby.Name
            };

            using (var dbContext = DbAppContextManager.GetContext())
            {
                dbContext.Lobbies.Add(newLobby);
                dbContext.SaveChanges();
                return Ok(newLobby);
            }
        }
        public IHttpActionResult Put([FromBody]Lobby lobby, int id)
        {
            using (var dbContext = DbAppContextManager.GetContext())
            {
                Lobby newLobby = null;
                var lobbyQuery   =
                    from l in dbContext.Lobbies
                    where l.Id == id
                    select l;

                var result = lobbyQuery.FirstOrDefault();

                if (result != null)
                {
                    result.GameId = lobby.GameId;
                    result.Name = lobby.Name;
                    result.GroupId = lobby.GroupId;
                }
                else
                {
                    newLobby= new Lobby
                    {
                        GameId = lobby.GameId,
                        Name = lobby.Name,
                        GroupId = lobby.GroupId
                    };
                    dbContext.Lobbies.Add(newLobby);
                }

                dbContext.SaveChanges();
                if (newLobby != null)
                {
                    return Ok(newLobby);
                }
                else
                {
                    return Ok(result);
                }
            }
        }
    }
}



//https://stackoverflow.com/questions/38557170/simple-example-using-system-data-sqlite-with-entity-framework-6