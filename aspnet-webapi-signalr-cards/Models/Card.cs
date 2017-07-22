using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Suit { get; set; }
        public string FrontImageFileName { get; set; }
        public string BackImageFileName { get; set; }
        [ForeignKey("DeckId")]
        public virtual Deck Deck { get; set; }
    }
}