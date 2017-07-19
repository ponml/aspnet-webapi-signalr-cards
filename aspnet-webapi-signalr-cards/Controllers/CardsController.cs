using aspnet_webapi_signalr_cards.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace aspnet_webapi_signalr_cards.Controllers
{
    public class CardsController : ApiController
    {
        private string _cardsDB = "CARDS_DB";
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

        public List<Card> GetAllCards()
        {
            var cards = LoadJson();
            return cards;
        }

        public IHttpActionResult GetCard(Guid id)
        {
            var context = new MongoDBContext(_cardsDB);
            var cards =
                from deck in context.Database.GetCollection<Deck>("decks").Find<Deck>(x => x.Name == "Standard").ToList<Deck>()
                select new
                {
                    Id = deck.Id,
                    Name = deck.Name,
                    Cards =
                        from card in deck.Cards
                        select new
                        {
                            Id = card.Id,
                            Name = card.Name,
                            Value = card.Value
                        }
                };

            var card = cards.FirstOrDefault();
            if (card == null)
            {
                return NotFound();
            }
            return Ok(card);
        }

        public object Post(Card card)
        {
            var context = new MongoDBContext(_cardsDB);
            context.Database.Insert
            return null;
        }

        //public IHttpActionResult GetCard(int value, string suit)
        //{
        //    var context = new MongoDBContext(_cardsDB);
        //    var cards = context.Database.GetCollection<Deck>("decks").Find<Deck>(null);
        //    var card = cards.FirstOrDefault();
        //    if (card == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(card);
        //}
    }
}
