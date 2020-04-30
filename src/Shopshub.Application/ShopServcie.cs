using Microsoft.Extensions.Configuration;
using System;

namespace Shopshub.Application
{
    public class ShopServcie : IShopServcie
    {
        private readonly IConfiguration _configuration;
        public ShopServcie(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSiteName()
        {
            return _configuration["SiteName"];
        }
    }
}
