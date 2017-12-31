using aspnet_webapi_signalr_cards;
using aspnet_webapi_signalr_cards.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace game_app_server.Migrations
{
    public class Migration1 : IMigrate
    {
        public int MigrationVersion { get { return 1; } }

        public void Migrate(DbAppContext dbContext)
        {
            
            var migrationsTable = "CREATE TABLE `Migrations` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Version` INTEGER NOT NULL UNIQUE, `Name` INTEGER )";
            var playersTable = "CREATE TABLE `Players` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Name` TEXT, `TeamId` TEXT, `Score` REAL, `WebSocketId` TEXT UNIQUE, `IsDealer` INTEGER NOT NULL )";
            var lobbiesTable = "CREATE TABLE 'Lobbies' ( `Name` TEXT UNIQUE, `Id` INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, `GroupId` TEXT UNIQUE, `GameId` INTEGER )";
            var decksTable = "CREATE TABLE 'Decks' ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` TEXT NOT NULL )";
            var cardsTable = "CREATE TABLE 'Cards' ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Value` INTEGER NOT NULL, `Name` TEXT, `DeckId` INTEGER NOT NULL, `Suit` TEXT, `FrontImageFileName` TEXT, `BackImageFileName` TEXT, FOREIGN KEY(`DeckId`) REFERENCES 'Decks'('Id') ON DELETE SET NULL )";

            dbContext.Database.ExecuteSqlCommand(migrationsTable);
            dbContext.Database.ExecuteSqlCommand(playersTable);
            dbContext.Database.ExecuteSqlCommand(lobbiesTable);
            dbContext.Database.ExecuteSqlCommand(decksTable);
            dbContext.Database.ExecuteSqlCommand(cardsTable);
            dbContext.SaveChanges();

        }
    }
}