using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopshub.DbMigrator;
using Shopshub.Domain;
using System;
using System.IO;
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
            //.ConfigureHostConfiguration(configHost =>
            //{
            //    configHost.SetBasePath(Directory.GetCurrentDirectory());
            //    configHost.AddJsonFile("hostsettings.json", optional: true);
            //    configHost.AddEnvironmentVariables(prefix: "PREFIX_");
            //    configHost.AddCommandLine(args);
            //})
            .ConfigureAppConfiguration((hostContext, configApp) =>
            {
                configApp.AddJsonFile("appsettings.json", optional: true);
                //configApp.AddJsonFile(
                //    $"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                //    optional: true);
                //configApp.AddEnvironmentVariables(prefix: "PREFIX_");
                //configApp.AddCommandLine(args);
            })
            .ConfigureServices((hostContext, services) =>
            {

                services.AddDbContext<ShopshubContext>(options =>
                {
                    options.UseSqlite(hostContext.Configuration.GetConnectionString("Default"));
                });
                services.AddTransient<InitialDataService>();
                services.AddHostedService<DbMigratorService>();
                services.AddLogging();
            })
            .ConfigureLogging((hostContext, configLogging) =>
            {
                configLogging.AddConsole();
                configLogging.AddDebug();
            });
    }
}
