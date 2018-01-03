using aspnet_webapi_signalr_cards;
using aspnet_webapi_signalr_cards.Migrations;
using aspnet_webapi_signalr_cards.Models;
using Newtonsoft.Json;
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

            //insert a standard deck

            var standardDeck = new Deck
            {
                Name = "Standard",
                Id = 1
            };

            dbContext.Decks.Add(standardDeck);
            dbContext.SaveChanges();

            var cardJson = "[{ 'Id':1,'Name':'Ace of Spades','Value':1,'Suit':'Spades','FrontImageFileName':'0_1.svg','BackImageFileName':'back.png'},{ 'Id':2,'Name':'Two of Spades','Value':2,'Suit':'Spades','FrontImageFileName':'0_2.svg','BackImageFileName':'back.png'},{ 'Id':3,'Name':'Three of Spades','Value':3,'Suit':'Spades','FrontImageFileName':'0_3.svg','BackImageFileName':'back.png'},{ 'Id':4,'Name':'Four of Spades','Value':4,'Suit':'Spades','FrontImageFileName':'0_4.svg','BackImageFileName':'back.png'},{ 'Id':5,'Name':'Five of Spades','Value':5,'Suit':'Spades','FrontImageFileName':'0_5.svg','BackImageFileName':'back.png'},{ 'Id':6,'Name':'Six of Spades','Value':6,'Suit':'Spades','FrontImageFileName':'0_6.svg','BackImageFileName':'back.png'},{ 'Id':7,'Name':'Seven of Spades','Value':7,'Suit':'Spades','FrontImageFileName':'0_7.svg','BackImageFileName':'back.png'},{ 'Id':8,'Name':'Eight of Spades','Value':8,'Suit':'Spades','FrontImageFileName':'0_8.svg','BackImageFileName':'back.png'},{ 'Id':9,'Name':'Nine of Spades','Value':9,'Suit':'Spades','FrontImageFileName':'0_9.svg','BackImageFileName':'back.png'},{ 'Id':10,'Name':'Ten of Spades','Value':10,'Suit':'Spades','FrontImageFileName':'0_10.svg','BackImageFileName':'back.png'},{ 'Id':11,'Name':'Jack of Spades','Value':11,'Suit':'Spades','FrontImageFileName':'0_11.svg','BackImageFileName':'back.png'},{ 'Id':12,'Name':'Queen of Spades','Value':12,'Suit':'Spades','FrontImageFileName':'0_12.svg','BackImageFileName':'back.png'},{ 'Id':13,'Name':'King of Spades','Value':13,'Suit':'Spades','FrontImageFileName':'0_13.svg','BackImageFileName':'back.png'},{ 'Id':14,'Name':'Ace of Hearts','Value':1,'Suit':'Hearts','FrontImageFileName':'1_1.svg','BackImageFileName':'back.png'},{ 'Id':15,'Name':'Two of Hearts','Value':2,'Suit':'Hearts','FrontImageFileName':'1_2.svg','BackImageFileName':'back.png'},{ 'Id':16,'Name':'Three of Hearts','Value':3,'Suit':'Hearts','FrontImageFileName':'1_3.svg','BackImageFileName':'back.png'},{ 'Id':17,'Name':'Four of Hearts','Value':4,'Suit':'Hearts','FrontImageFileName':'1_4.svg','BackImageFileName':'back.png'},{ 'Id':18,'Name':'Five of Hearts','Value':5,'Suit':'Hearts','FrontImageFileName':'1_5.svg','BackImageFileName':'back.png'},{ 'Id':19,'Name':'Six of Hearts','Value':6,'Suit':'Hearts','FrontImageFileName':'1_6.svg','BackImageFileName':'back.png'},{ 'Id':20,'Name':'Seven of Hearts','Value':7,'Suit':'Hearts','FrontImageFileName':'1_7.svg','BackImageFileName':'back.png'},{ 'Id':21,'Name':'Eight of Hearts','Value':8,'Suit':'Hearts','FrontImageFileName':'1_8.svg','BackImageFileName':'back.png'},{ 'Id':22,'Name':'Nine of Hearts','Value':9,'Suit':'Hearts','FrontImageFileName':'1_9.svg','BackImageFileName':'back.png'},{ 'Id':23,'Name':'Ten of Hearts','Value':10,'Suit':'Hearts','FrontImageFileName':'1_10.svg','BackImageFileName':'back.png'},{ 'Id':24,'Name':'Jack of Hearts','Value':11,'Suit':'Hearts','FrontImageFileName':'1_11.svg','BackImageFileName':'back.png'},{ 'Id':25,'Name':'Queen of Hearts','Value':12,'Suit':'Hearts','FrontImageFileName':'1_12.svg','BackImageFileName':'back.png'},{ 'Id':26,'Name':'King of Hearts','Value':13,'Suit':'Hearts','FrontImageFileName':'1_13.svg','BackImageFileName':'back.png'},{ 'Id':27,'Name':'Ace of Clubs','Value':1,'Suit':'Clubs','FrontImageFileName':'2_1.svg','BackImageFileName':'back.png'},{ 'Id':28,'Name':'Two of Clubs','Value':2,'Suit':'Clubs','FrontImageFileName':'2_2.svg','BackImageFileName':'back.png'},{ 'Id':29,'Name':'Three of Clubs','Value':3,'Suit':'Clubs','FrontImageFileName':'2_3.svg','BackImageFileName':'back.png'},{ 'Id':30,'Name':'Four of Clubs','Value':4,'Suit':'Clubs','FrontImageFileName':'2_4.svg','BackImageFileName':'back.png'},{ 'Id':31,'Name':'Five of Clubs','Value':5,'Suit':'Clubs','FrontImageFileName':'2_5.svg','BackImageFileName':'back.png'},{ 'Id':32,'Name':'Six of Clubs','Value':6,'Suit':'Clubs','FrontImageFileName':'2_6.svg','BackImageFileName':'back.png'},{ 'Id':33,'Name':'Seven of Clubs','Value':7,'Suit':'Clubs','FrontImageFileName':'2_7.svg','BackImageFileName':'back.png'},{ 'Id':34,'Name':'Eight of Clubs','Value':8,'Suit':'Clubs','FrontImageFileName':'2_8.svg','BackImageFileName':'back.png'},{ 'Id':35,'Name':'Nine of Clubs','Value':9,'Suit':'Clubs','FrontImageFileName':'2_9.svg','BackImageFileName':'back.png'},{ 'Id':36,'Name':'Ten of Clubs','Value':10,'Suit':'Clubs','FrontImageFileName':'2_10.svg','BackImageFileName':'back.png'},{ 'Id':37,'Name':'Jack of Clubs','Value':11,'Suit':'Clubs','FrontImageFileName':'2_11.svg','BackImageFileName':'back.png'},{ 'Id':38,'Name':'Queen of Clubs','Value':12,'Suit':'Clubs','FrontImageFileName':'2_12.svg','BackImageFileName':'back.png'},{ 'Id':39,'Name':'King of Clubs','Value':13,'Suit':'Clubs','FrontImageFileName':'2_13.svg','BackImageFileName':'back.png'},{ 'Id':40,'Name':'Ace of Diamonds','Value':1,'Suit':'Diamonds','FrontImageFileName':'3_1.svg','BackImageFileName':'back.png'},{ 'Id':41,'Name':'Two of Diamonds','Value':2,'Suit':'Diamonds','FrontImageFileName':'3_2.svg','BackImageFileName':'back.png'},{ 'Id':42,'Name':'Three of Diamonds','Value':3,'Suit':'Diamonds','FrontImageFileName':'3_3.svg','BackImageFileName':'back.png'},{ 'Id':43,'Name':'Four of Diamonds','Value':4,'Suit':'Diamonds','FrontImageFileName':'3_4.svg','BackImageFileName':'back.png'},{ 'Id':44,'Name':'Five of Diamonds','Value':5,'Suit':'Diamonds','FrontImageFileName':'3_5.svg','BackImageFileName':'back.png'},{ 'Id':45,'Name':'Six of Diamonds','Value':6,'Suit':'Diamonds','FrontImageFileName':'3_6.svg','BackImageFileName':'back.png'},{ 'Id':46,'Name':'Seven of Diamonds','Value':7,'Suit':'Diamonds','FrontImageFileName':'3_7.svg','BackImageFileName':'back.png'},{ 'Id':47,'Name':'Eight of Diamonds','Value':8,'Suit':'Diamonds','FrontImageFileName':'3_8.svg','BackImageFileName':'back.png'},{ 'Id':48,'Name':'Nine of Diamonds','Value':9,'Suit':'Diamonds','FrontImageFileName':'3_9.svg','BackImageFileName':'back.png'},{ 'Id':49,'Name':'Ten of Diamonds','Value':10,'Suit':'Diamonds','FrontImageFileName':'3_10.svg','BackImageFileName':'back.png'},{ 'Id':50,'Name':'Jack of Diamonds','Value':11,'Suit':'Diamonds','FrontImageFileName':'3_11.svg','BackImageFileName':'back.png'},{ 'Id':51,'Name':'Queen of Diamonds','Value':12,'Suit':'Diamonds','FrontImageFileName':'3_12.svg','BackImageFileName':'back.png'},{ 'Id':52,'Name':'King of Diamonds','Value':13,'Suit':'Diamonds','FrontImageFileName':'3_13.svg','BackImageFileName':'back.png'}]";
            var cards = JsonConvert.DeserializeObject<Card[]>(cardJson);

            foreach (var card in cards)
            {
                card.DeckId = 1;
                dbContext.Cards.Add(card);
            }

            dbContext.SaveChanges();
        }
    }
}