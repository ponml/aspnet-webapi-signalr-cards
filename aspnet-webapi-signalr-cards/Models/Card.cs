using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Suit { get; set; }
        public string FrontImageFileName { get; set; }
        public string BackImageFileName { get; set; }
    }
}