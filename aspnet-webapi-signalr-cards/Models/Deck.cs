using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IEnumerable<Card> Cards { get; set; }
    }
}