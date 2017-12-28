using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace game_app_server.Migrations
{
    public static class Initialize
    {

        //ping the connection string db
        //check if migration table exists
        //if doesn't 
        //create it, run migrations
        //else
        //check our biggest version, vs the tables biggest version
        public static void RunMigrations()
        {
            var playersTable = "CREATE TABLE `Players` ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Name` TEXT, `TeamId` TEXT, `Score` REAL, `WebSocketId` TEXT UNIQUE, `IsDealer` INTEGER NOT NULL )";
            var lobbiesTable = "CREATE TABLE 'Lobbies' ( `Name` TEXT UNIQUE, `Id` INTEGER PRIMARY KEY AUTOINCREMENT UNIQUE, `GroupId` TEXT UNIQUE, `GameId` INTEGER )";
            var decksTable = "CREATE TABLE 'Decks' ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` TEXT NOT NULL )";
            var cardsTable = "CREATE TABLE 'Cards' ( `Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `Value` INTEGER NOT NULL, `Name` TEXT, `DeckId` INTEGER NOT NULL, `Suit` TEXT, `FrontImageFileName` TEXT, `BackImageFileName` TEXT, FOREIGN KEY(`DeckId`) REFERENCES 'Decks'('Id') ON DELETE SET NULL )";
        }
    }
}