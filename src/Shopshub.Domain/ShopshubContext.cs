using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Domain
{
    public class ShopshubContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public ShopshubContext(DbContextOptions<ShopshubContext> options)
            : base(options)
        {

        }

    }
}
