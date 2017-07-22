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
    public class CardsController : ApiController
    {
        private List<Card> LoadJson()
        {
            var root = AppDomain.CurrentDomain.BaseDirectory;
            using (StreamReader r = new StreamReader(root + "/Tables/cards.json"))
            {
                string json = r.ReadToEnd();
                var cards = JsonConvert.DeserializeObject<List<Card>>(json);
                return cards;
            }
        }

        public object[] GetAllCards()
        {
            using (var dbContext = new CardsContext("C:\\SQLITE\\dbs\\cards.db"))
            {
                var cards =
                    from card in dbContext.Cards
                    where card.DeckId == 1
                    select new
                    {
                        Id = card.Id,
                        DeckName = card.Deck.Name
                    };

                var result = cards.ToArray();
                return result;
            }
        }

        public IHttpActionResult GetCard(int id)
        {
            var cards = LoadJson();
            var card = cards.FirstOrDefault((p) => p.Id == id);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        public IHttpActionResult GetCard(int value, string suit)
        {
            var cards = LoadJson();
            var card = cards.FirstOrDefault((p) => p.Value == value && p.Suit == suit);
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }
    }
}



//https://stackoverflow.com/questions/38557170/simple-example-using-system-data-sqlite-with-entity-framework-6