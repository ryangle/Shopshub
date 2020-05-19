using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Shopshub.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Shopshub.DbMigrator
{
    public class InitialDataService
    {
        private readonly ShopshubContext _shopshubContext;
        private readonly ILogger<InitialDataService> _logger;
        public InitialDataService(ILogger<InitialDataService> logger, ShopshubContext shopshubContext)
        {
            _logger = logger;
            _shopshubContext = shopshubContext;
        }
        public void Run()
        {
            foreach (var m in InitialMenu())
            {
                _shopshubContext.Menus.Add(m);
            }
            _shopshubContext.SaveChanges();
            _logger.LogInformation("InitialDataService complated");
        }

        private List<Menu> InitialMenu()
        {
            var menus = new List<Menu>();

            #region 其他管理
            var qtgl = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "其它管理",
                Icon = "fa fa-slideshare",
                Href = "",
                Target = "",
                ParentId = Guid.Empty,
                CreationTime = DateTime.Now,
                Order = 1
            };
            menus.Add(qtgl);
            var sxcd = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "失效菜单",
                Icon = "fa fa-superpowers",
                Href = "layuimini/page/error.html",
                Target = "_self",
                ParentId = qtgl.Id,
                CreationTime = DateTime.Now,
                Order = 2
            };
            menus.Add(sxcd);
            var djcd = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "多级菜单",
                Icon = "fa fa-meetup",
                Href = "",
                Target = "",
                ParentId = qtgl.Id,
                CreationTime = DateTime.Now,
                Order = 3
            };
            menus.Add(djcd);
            var ann = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "按钮1",
                Icon = "fa fa-calendar",
                Href = "adminstatic/page/button.html?v=1",
                Target = "_self",
                ParentId = djcd.Id,
                CreationTime = DateTime.Now,
                Order = 4
            };
            menus.Add(ann);
            #endregion

            #region 组件管理
            var zjgl = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "组件管理",
                Icon = "fa fa-fa-lemon-o",
                Href = "",
                Target = "_self",
                ParentId = Guid.Empty,
                CreationTime = DateTime.Now,
                Order = 5
            };
            menus.Add(zjgl);
            var tglb = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "图标列表",
                Icon = "fa fa-dot-circle-o",
                Href = "adminstatic/page/icon.html",
                Target = "_self",
                ParentId = zjgl.Id,
                CreationTime = DateTime.Now,
                Order = 6
            };
            menus.Add(tglb);
            var tbxz = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "图标选择",
                Icon = "fa fa-adn",
                Href = "adminstatic/page/icon-picker.html",
                Target = "_self",
                ParentId = zjgl.Id,
                CreationTime = DateTime.Now,
                Order = 7
            };
            menus.Add(tbxz);
            #endregion

            #region 常规管理
            var cggl = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "常规管理",
                Icon = "fa fa-address-book",
                Href = "",
                Target = "_self",
                ParentId = Guid.Empty,
                CreationTime = DateTime.Now,
                Order = 8
            };
            menus.Add(cggl);
            var zymb = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "主页模板",
                Icon = "fa fa-home",
                Href = "",
                Target = "_self",
                ParentId = cggl.Id,
                CreationTime = DateTime.Now,
                Order = 9
            };
            menus.Add(zymb);
            var cdgl = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "菜单管理",
                Icon = "fa fa-window-maximize",
                Href = "adminstatic/page/menu.html",
                Target = "_self",
                ParentId = cggl.Id,
                CreationTime = DateTime.Now,
                Order = 10
            };
            menus.Add(cdgl);
            var xtsz = new Menu
            {
                Id = Guid.NewGuid(),
                Title = "系统设置",
                Icon = "fa fa-gears",
                Href = "adminstatic/page/setting.html",
                Target = "_self",
                ParentId = cggl.Id,
                CreationTime = DateTime.Now,
                Order = 11
            };
            menus.Add(xtsz);
            #endregion
            return menus;
        }
    }
}
