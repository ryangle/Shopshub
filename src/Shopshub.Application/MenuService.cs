using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopshub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopshub.Application
{
    public class MenuService
    {
        private readonly ShopshubContext _shopshubContext;
        public MenuService(ShopshubContext shopshubContext)
        {
            _shopshubContext = shopshubContext;
        }

        public Guid AddShop(Shop shop)
        {
            shop.Id = Guid.NewGuid();
            _shopshubContext.Shops.Add(shop);
            _shopshubContext.SaveChanges();
            return shop.Id;
        }

        public List<MenuInfo> GetMenus()
        {
            var menus = _shopshubContext.Menus.Where(m => true).OrderByDescending(m => m.Order).ToList();
            return MenuTree(menus, Guid.Empty);
        }
        private List<MenuInfo> MenuTree(List<Menu> list, Guid parentId)
        {
            var result = new List<MenuInfo>();
            List<Menu> menus = list.FindAll(t => t.ParentId == parentId);
            if (menus.Count > 0)
            {
                foreach (var m in menus)
                {
                    var menuInfo = new MenuInfo
                    {
                        Icon = m.Icon,
                        Href = m.Href,
                        Target = m.Target,
                        Title = m.Title,
                        Child = MenuTree(list, m.Id).ToArray()
                    };
                    result.Add(menuInfo);
                }
            }
            return result;
        }
    }
}
