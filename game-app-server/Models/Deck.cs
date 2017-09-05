using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace game_app_server.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}