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
    public class DecksController : ApiController
    {
        public object[] GetAllDecks()
        {
            using (var dbContext = CardsContextManager.GetContext())
            {
                var deckQuery = (
                    from deck in dbContext.Decks
                    select new
                    {
                        Id = deck.Id,
                        Name = deck.Name,
                        Cards = 
                            from card in deck.Cards
                            select card
                    }).ToArray();

                var result = deckQuery.ToArray();
                return result;
            }
        }

        public IHttpActionResult GetDeck(int id)
        {
            using (var dbContext = CardsContextManager.GetContext())
            {
                var deckQuery = (
                    from deck in dbContext.Decks
                    where deck.Id == id
                    select new
                    {
                        Id = deck.Id,
                        Name = deck.Name,
                        Cards =
                            from card in deck.Cards
                            select card
                    });

                var result = deckQuery.FirstOrDefault();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
        }
    }
}



//https://stackoverflow.com/questions/38557170/simple-example-using-system-data-sqlite-with-entity-framework-6