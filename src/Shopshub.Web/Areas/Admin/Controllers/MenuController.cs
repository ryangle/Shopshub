using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopshub.Application;
using Shopshub.Web.Models;

namespace Shopshub.Web.Area.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly ILogger<MenuController> _logger;
        private readonly ShopServcie _shopServcie;

        public MenuController(ILogger<MenuController> logger, ShopServcie shopServcie)
        {
            _logger = logger;
            _shopServcie = shopServcie;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
