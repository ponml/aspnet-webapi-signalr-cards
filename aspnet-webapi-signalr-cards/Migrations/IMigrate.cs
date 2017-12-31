using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_webapi_signalr_cards.Migrations
{
    interface IMigrate
    {
        void Migrate(DbAppContext dbContext);
        int MigrationVersion { get; }
    }
}
