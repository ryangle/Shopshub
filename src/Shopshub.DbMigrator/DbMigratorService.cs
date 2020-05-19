using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shopshub.DbMigrator
{
    public class DbMigratorService : IHostedService
    {
        private InitialDataService _initialDataService;
        public DbMigratorService(InitialDataService initialDataService)
        {
            _initialDataService = initialDataService;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _initialDataService.Run();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
