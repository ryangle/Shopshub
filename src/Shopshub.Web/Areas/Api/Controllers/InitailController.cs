using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopshub.Application;
using Shopshub.Domain;
using Shopshub.Web.Models;

namespace Shopshub.Web.Area.Controllers
{
    [Area("Api")]
    public class InitailController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShopServcie _shopServcie;
        private readonly MenuService _menuService;

        public InitailController(ILogger<HomeController> logger,
            ShopServcie shopServcie,
            MenuService menuService)
        {
            _logger = logger;
            _shopServcie = shopServcie;
            _menuService = menuService;
        }
        public JsonResult<InitialData> Index()
        {
            var menuInfo = _menuService.GetMenus().ToArray();
            return new JsonResult<InitialData>
            {
                Code = 1,
                Msg = "",
                Data = new InitialData
                {
                    HomeInfo = new HomeInfo
                    {
                        Title = "首页",
                        Href = "/admin/home/main"
                    },
                    LogoInfo = new LogoInfo
                    {
                        Title = "Shopshub",
                        Image = "/adminstatic/images/logo.png",
                        Href = ""
                    },
                    MenuInfo = menuInfo


                }
            };
        }

    }
}
