using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards.Models
{
    public class Migration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }
}