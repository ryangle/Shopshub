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
    [Area("Api")]
    public class ClearControlle : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopServcie _shopServcie;

        public ClearControlle(ILogger<HomeController> logger, ShopServcie shopServcie)
        {
            _logger = logger;
            _shopServcie = shopServcie;
        }
        public JsonResult<string> Index()
        {
            return new JsonResult<string>
            {
                Code = 1,
                Msg = "清理成功",
                Data = ""
            };
        }

    }
}
