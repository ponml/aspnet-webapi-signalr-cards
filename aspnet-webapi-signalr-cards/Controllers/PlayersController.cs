 ﻿using aspnet_webapi_signalr_cards.Models;
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
    public class PlayersController : ApiController
    {

        public IHttpActionResult GetPlayer(int id)
        {
            using (var dbContext = DbAppContextManager.GetContext())
            {
                var playerQuery =
                    from player in dbContext.Players
                    where player.Id == id
                    select player;

                var result = playerQuery.FirstOrDefault();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }

        public IHttpActionResult Post([FromBody]Player player)
        {
            var newPlayer = new Player
            {
                WebSocketId = player.WebSocketId,
                Name = player.Name,
                TeamId = player.TeamId,
                Score = player.Score
            };

            using (var dbContext = DbAppContextManager.GetContext())
            {
                dbContext.Players.Add(newPlayer);
                dbContext.SaveChanges();
                return Ok(newPlayer);
            }
        }
        public IHttpActionResult Put([FromBody]Player player, int id)
        {
            using (var dbContext = DbAppContextManager.GetContext())
            {
                Player newPlayer = null;

                var playerQuery =
                    from p in dbContext.Players
                    where p.Id == id
                    select p;

                var result = playerQuery.FirstOrDefault();

                if (result != null)
                {
                    result.TeamId = player.TeamId;
                    result.Score = player.Score;
                }
                else
                {
                    newPlayer = new Player
                    {
                        WebSocketId = player.WebSocketId,
                        Name = player.Name,
                        TeamId = player.TeamId,
                        Score = player.Score
                    };
                    dbContext.Players.Add(newPlayer);
                }

                dbContext.SaveChanges();
                if (newPlayer != null)
                {
                    return Ok(newPlayer);
                }
                else
                {
                    return Ok(result);
                }
            }
        }
    }
}
 
 
 
 //https://stackoverflow.com/questions/38557170/simple-example-using-system-data-sqlite-with-entity-framework
