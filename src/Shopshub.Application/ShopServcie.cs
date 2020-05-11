using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopshub.Dal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopshub.Application
{
    public class ShopServcie : IShopServcie
    {
        private readonly IConfiguration _configuration;
        private readonly ShopshubContext _shopshubContext;
        public ShopServcie(IConfiguration configuration, ShopshubContext shopshubContext)
        {
            _configuration = configuration;
            _shopshubContext = shopshubContext;
        }

        public Guid AddShop(Shop shop)
        {
            shop.Id = Guid.NewGuid();
            _shopshubContext.Shops.Add(shop);
            _shopshubContext.SaveChanges();
            return shop.Id;
        }

        public List<Shop> GetShops()
        {
            return _shopshubContext.Shops.Where(s => true).ToList();
        }
        public string GetSiteName()
        {
            return _configuration["SiteName"];
        }
    }
}
