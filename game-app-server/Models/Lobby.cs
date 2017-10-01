using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Lobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupId { get; set; }
        public int? GameId { get; set; }
    }
}