using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Deck
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Card> Cards { get; set; }
    }
}