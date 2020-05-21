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

namespace Shopshub.Web.Api.Controllers
{
    [Area("Api")]
    public class DataController : Controller
    {
        private readonly ILogger<DataController> _logger;
        private readonly ShopServcie _shopServcie;
        private readonly MenuService _menuService;
        private readonly UserServcie _userServcie;

        public DataController(ILogger<DataController> logger,
            ShopServcie shopServcie,
            MenuService menuService,
            UserServcie userServcie)
        {
            _logger = logger;
            _shopServcie = shopServcie;
            _menuService = menuService;
            _userServcie = userServcie;
        }
        public JsonResult<MenuDto[]> Menu()
        {
            var menuInfo = _menuService.GetMenuList().ToArray();
            return new JsonResult<MenuDto[]>
            {
                Code = 0,
                Msg = "",
                Count = menuInfo.Length,
                Data = menuInfo
            };
        }
        public JsonResult<InitialData> Initial()
        {
            var menuInfo = _menuService.GetMenus().ToArray();
            return new JsonResult<InitialData>
            {
                Code = 1,
                Msg = "",
                Count = 0,
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
        public JsonResult<string> Clear()
        {
            return new JsonResult<string>
            {
                Code = 1,
                Msg = "清理成功",
                Data = ""
            };
        }
        public JsonResult<UserDto[]> Users()
        {
            var users = _userServcie.GetUsers().ToArray();
            return new JsonResult<UserDto[]>
            {
                Code = 0,
                Msg = "",
                Count = users.Length,
                Data = users
            };
        }
    }
}
