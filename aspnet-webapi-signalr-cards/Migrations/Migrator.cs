using aspnet_webapi_signalr_cards.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace aspnet_webapi_signalr_cards.Migrations
{
    public static class Migrator
    {
        public static void RunMigrations()
        {
            var type = typeof(IMigrate);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass);

            using (var dbContext = DbAppContextManager.GetContext())
            {
                var migrationsToRun = CheckForMigrations(dbContext);
                var maxVersion = migrationsToRun != null && migrationsToRun.Any()
                    ? migrationsToRun.Max(m => m.Version)
                    : 0;

                foreach (var migrateType in types)
                {
                    var instance = (IMigrate)Activator.CreateInstance(migrateType);

                    var migrationVersion = instance.MigrationVersion;

                    if (maxVersion == 0 || migrationVersion > maxVersion)
                    {
                        instance.Migrate(dbContext);
                        dbContext.Migrations.Add(new Migration
                        {
                            Version = instance.MigrationVersion
                        });
                        dbContext.SaveChanges();
                    }
                }
            }
        }

        private static Migration[] CheckForMigrations(DbAppContext dbContext)
        {
            var migrations = new List<Migration>();
            try
            {
                var migrationQuery =
                    from migration in dbContext.Migrations
                    select migration;

                migrations.AddRange(migrationQuery.ToArray());
                return migrations.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Failed to get any migrations: {0}", e.ToString()));
            }
            return migrations.ToArray();
        }
    }
}