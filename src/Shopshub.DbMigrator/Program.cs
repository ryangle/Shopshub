using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shopshub.DbMigrator;
using System;
using System.Threading.Tasks;

namespace Shopshub.Migrator
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).RunConsoleAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<InitialDataService>();
                    services.AddHostedService<DbMigratorService>();
                });
    }
}
