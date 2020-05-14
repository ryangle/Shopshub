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
    public class InitailController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IShopServcie _shopServcie;

        public InitailController(ILogger<HomeController> logger, IShopServcie shopServcie)
        {
            _logger = logger;
            _shopServcie = shopServcie;
        }
        public JsonResult<InitialData> Index()
        {
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
                    MenuInfo = new [] {
                        new MenuInfo {
                            Title = "常规管理",
                            Icon = "fa fa-address-book",
                            Href = "",
                            Target = "_self",
                            Child = new []{
                                new MenuInfo{
                                    Title = "主页模板",
                                    Icon = "fa fa-home",
                                    Href = "",
                                    Target = "_self", 
                                    Child = new []{ 
                                        new MenuInfo{ 
                                            Title = "主页一",
                                            Icon = "fa fa-tachometer",
                                            Href = "/admin/home/main",
                                            Target = "_self"
                                        }
                                    }
                                }
                            }
                        }
                    }


                }
            };
        }

    }
}
