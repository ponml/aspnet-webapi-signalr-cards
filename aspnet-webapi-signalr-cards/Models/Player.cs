using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string WebSocketId { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int Score { get; set; }
        public bool IsDealer { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}