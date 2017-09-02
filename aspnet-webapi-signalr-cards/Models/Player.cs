using aspnet_webapi_signalr_cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Player
    {
        int Id { get; set; }
        string WebSocketId { get; set; }
        int TeamId { get; set; }
        int Score { get; set; }
        bool IsDealer { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}