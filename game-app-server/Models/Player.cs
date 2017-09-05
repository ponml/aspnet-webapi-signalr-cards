using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace game_app_server.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string WebSocketId { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public float Score { get; set; }
        public int IsDealer { get; set; }
    }
}