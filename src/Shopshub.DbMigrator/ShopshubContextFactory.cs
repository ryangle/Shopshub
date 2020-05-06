using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shopshub.Dal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shopshub.DbMigrator
{
    public class ShopshubContextFactory : IDesignTimeDbContextFactory<ShopshubContext>
    {
        public ShopshubContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var optionsBuilder = new DbContextOptionsBuilder<ShopshubContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("Default"));

            return new ShopshubContext(optionsBuilder.Options);
        }
        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
