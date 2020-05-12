using Shopshub.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Application
{
    public interface IShopServcie
    {
        string GetSiteName();
        Guid AddShop(Shop shop);
        List<Shop> GetShops();
    }
}
