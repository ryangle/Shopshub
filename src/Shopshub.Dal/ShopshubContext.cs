using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Dal
{
    public class ShopshubContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }

        public ShopshubContext(DbContextOptions<ShopshubContext> options)
            : base(options)
        {

        }

    }
}
