using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspnet_webapi_signalr_cards
{
    public class MongoDBContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }

        public IMongoDatabase Database { get; set; }

        public MongoDBContext(string databaseName)
        {
            try
            {
                //MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                //if (IsSSL)
                //{
                //    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                //}
                var mongoClient = new MongoClient();
                Database = mongoClient.GetDatabase(databaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Can not access to db server.", ex);
            }
        }
    }
}