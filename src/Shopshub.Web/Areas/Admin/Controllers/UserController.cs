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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ShopServcie _shopServcie;

        public UserController(ILogger<UserController> logger, ShopServcie shopServcie)
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
