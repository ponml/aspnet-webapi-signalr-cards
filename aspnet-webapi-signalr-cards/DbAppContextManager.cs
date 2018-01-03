using aspnet_webapi_signalr_cards.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards
{
    public class DbAppContext : DbContext
    {
        public DbAppContext(string dataSourceString)
            :base(new SQLiteConnection ()
            {
                ConnectionString = new SQLiteConnectionStringBuilder() { DataSource = dataSourceString, ForeignKeys = true }.ConnectionString
            }, true)
        {
            Database.SetInitializer<DbAppContext>(null);
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Deck> Decks { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Lobby> Lobbies { get; set; }
        public DbSet<Migration> Migrations { get; set; }
    }

    public static class DbAppContextManager
    {
        public static DbAppContext GetContext()
        {
            return new DbAppContext("C:\\SQLITE\\dbs\\cards.db");
        }
    }
}