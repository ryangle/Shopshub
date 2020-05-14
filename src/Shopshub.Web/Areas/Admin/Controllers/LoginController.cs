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
    public class LoginController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShopServcie _shopServcie;

        public LoginController(ILogger<HomeController> logger, IShopServcie shopServcie)
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
