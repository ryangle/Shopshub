using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopshub.Application;
using Shopshub.Dal;
using Shopshub.Web.Models;

namespace Shopshub.Web.Controllers
{
    public class ShopsController : Controller
    {
        private readonly ILogger<ShopsController> _logger;
        private readonly IShopServcie _shopServcie;

        public ShopsController(ILogger<ShopsController> logger, IShopServcie shopServcie)
        {
            _logger = logger;
            _shopServcie = shopServcie;
        }
        public IActionResult List()
        {
            var shops = _shopServcie.GetShops();
            return View(shops);
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Shop shop)
        {
            _shopServcie.AddShop(shop);

            return View(shop);
        }
    }
}
