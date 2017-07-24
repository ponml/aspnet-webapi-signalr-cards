using aspnet_webapi_signalr_cards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards
{
    public class CardsContext : DbContext
    {
        public CardsContext(string dataSourceString)
            :base(new SQLiteConnection ()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = dataSourceString, ForeignKeys = true }.ConnectionString
            }, true)
        {
            Database.SetInitializer<CardsContext>(null);
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
    }

    public static class CardsContextManager
    {
        public static CardsContext GetContext()
        {
            return new CardsContext("C:\\SQLITE\\dbs\\cards.db");
        }
    }
}