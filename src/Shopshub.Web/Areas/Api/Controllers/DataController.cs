using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopshub.Application;
using Shopshub.Domain;
using Shopshub.Web.Models;

namespace Shopshub.Web.Api.Controllers
{
    [Authorize(Roles = "Administrator")]
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
        [AllowAnonymous]
        public string CountData()
        {
            return "{\"listed_companies_total\": 3574,\"listed_securities_total\": 20018,\"total_market_value\": 455294.1,\"circulation_market_value\": 370447.9,\"sh_pe_ratio\": 13.16,\"sz_pe_ratio\": 20.99}";
        }
        [AllowAnonymous]
        public string RankingList()
        {
            return "[{\"order\":1,\"stock_code\":\"601398\",\"stock_name\":\"工商银行\",\"market_capitalization\":14451.21},{\"order\":2,\"stock_code\":\"601857\",\"stock_name\": \"中国石油\",		\"market_capitalization\": 13148.07	},	{		\"order\": 3,\"stock_code\":\"601288\",\"stock_name\":\"农业银行\",\"market_capitalization\":11620.49},{\"order\": 4,\"stock_code\": \"601988\",		\"stock_name\": \"中国银行\",		\"market_capitalization\": 7608.64	},	{		\"order\": 5,		\"stock_code\": \"601318\",		\"stock_name\": \"中国平安\",		\"market_capitalization\": 7004.4	},{\"order\": 6,\"stock_code\": \"600519\",\"stock_name\": \"贵州茅台\",		\"market_capitalization\": 6934.21	},	{		\"order\": 7,		\"stock_code\": \"600028\",		\"stock_name\": \"中国石化\",		\"market_capitalization\": 5905.48	},	{		\"order\": 8,		\"stock_code\": \"600036\",		\"stock_name\": \"招商银行\",		\"market_capitalization\": 5891.63	},	{		\"order\": 9,		\"stock_code\": \"601628\",		\"stock_name\": \"中国人寿\",		\"market_capitalization\": 4583.26	},	{		\"order\": 10,		\"stock_code\": \"601088\",\"stock_name\":\"中国神华\",\"market_capitalization\":3298.21}]";
        }
        [AllowAnonymous]
        public string RegionCount()
        {
            return "[{\"region\":\"安徽\",\"sh_count\":46,\"sz_count\":57,\"count\":103},{\"region\":\"内蒙古\",\"sh_count\":16,\"sz_count\":10,\"count\":26},{\"region\":\"宁夏\",\"sh_count\":5,\"sz_count\":8,\"count\":13},{\"region\":\"青海\",\"sh_count\":8,\"sz_count\":4,\"count\":12},{\"region\":\"福建\",\"sh_count\":53,\"sz_count\":81,\"count\":134},{\"region\":\"山东\",\"sh_count\":74,\"sz_count\":126,\"count\":200},{\"region\":\"山西\",\"sh_count\":18,\"sz_count\":18,\"count\":36},{\"region\":\"陕西\",\"sh_count\":24,\"sz_count\":27,\"count\":51},{\"region\":\"上海\",\"sh_count\":185,\"sz_count\":78,\"count\":263},{\"region\":\"四川\",\"sh_count\":44,\"sz_count\":80,\"count\":124},{\"region\":\"天津\",\"sh_count\":25,\"sz_count\":24,\"count\":49},{\"region\":\"北京\",\"sh_count\":138,\"sz_count\":177,\"count\":315},{\"region\":\"西藏\",\"sh_count\":9,\"sz_count\":8,\"count\":17},{\"region\":\"新疆\",\"sh_count\":29,\"sz_count\":25,\"count\":54},{\"region\":\"云南\",\"sh_count\":15,\"sz_count\":20,\"count\":35},{\"region\":\"浙江\",\"sh_count\":193,\"sz_count\":239,\"count\":432},{\"region\":\"甘肃\",\"sh_count\":18,\"sz_count\":17,\"count\":35},{\"region\":\"重庆\",\"sh_count\":26,\"sz_count\":24,\"count\":50},{\"region\":\"广东\",\"sh_count\":83,\"sz_count\":506,\"count\":589},{\"region\":\"广西\",\"sh_count\":17,\"sz_count\":20,\"count\":37},{\"region\":\"贵州\",\"sh_count\":14,\"sz_count\":15,\"count\":29},{\"region\":\"海南\",\"sh_count\":9,\"sz_count\":20,\"count\":29},{\"region\":\"黑龙江\",\"sh_count\":27,\"sz_count\":11,\"count\":38},{\"region\":\"河北\",\"sh_count\":26,\"sz_count\":34,\"count\":60},{\"region\":\"河南\",\"sh_count\":31,\"sz_count\":49,\"count\":80},{\"region\":\"江苏\",\"sh_count\":176,\"sz_count\":226,\"count\":402},{\"region\":\"湖北\",\"sh_count\":41,\"sz_count\":61,\"count\":102},{\"region\":\"湖南\",\"sh_count\":33,\"sz_count\":73,\"count\":106},{\"region\":\"吉林\",\"sh_count\":20,\"sz_count\":24,\"count\":44},{\"region\":\"江西\",\"sh_count\":17,\"sz_count\":24,\"count\":41},{\"region\":\"辽宁\",\"sh_count\":34,\"sz_count\":42,\"count\":76}]";
        }
        [AllowAnonymous]
        public string MonthCount()
        {
            return "[{\"month\":\"1月\",\"sh_market_capitalization\":351041.76,\"sh_transaction_amount\":58096.59,\"sh_pe_ratio\":19.25,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"2月\",\"sh_market_capitalization\":334105.65,\"sh_transaction_amount\":32855.64,\"sh_pe_ratio\":18.29,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"3月\",\"sh_market_capitalization\":351041.76,\"sh_transaction_amount\":44281.8,\"sh_pe_ratio\":17.77,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"4月\",\"sh_market_capitalization\":317966.5,\"sh_transaction_amount\":34107.67,\"sh_pe_ratio\":17.31,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"5月\",\"sh_market_capitalization\":320700.9,\"sh_transaction_amount\":38396.92,\"sh_pe_ratio\":15.16,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"6月\",\"sh_market_capitalization\":299581.98,\"sh_transaction_amount\":31271.66,\"sh_pe_ratio\":14.06,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"7月\",\"sh_market_capitalization\":305437.19,\"sh_transaction_amount\":32764.68,\"sh_pe_ratio\":14.29,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"8月\",\"sh_market_capitalization\":290651.27,\"sh_transaction_amount\":28885.38,\"sh_pe_ratio\":13.58,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"9月\",\"sh_market_capitalization\":301557.15,\"sh_transaction_amount\":21689.22,\"sh_pe_ratio\":14.07,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"10月\",\"sh_market_capitalization\":278622.02,\"sh_transaction_amount\":24566.14,\"sh_pe_ratio\":13,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"11月\",\"sh_market_capitalization\":300285.49,\"sh_transaction_amount\":29652.15,\"sh_pe_ratio\":13.88,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0},{\"month\":\"12月\",\"sh_market_capitalization\":320765.48,\"sh_transaction_amount\":30985.4,\"sh_pe_ratio\":14.65,\"sz_market_capitalization\":0,\"sz_transaction_amount\":0,\"sz_pe_ratio\":0}]";
        }
        [AllowAnonymous]
        public string CsrcIndustry()
        {
            return "[{\"code\":\"A\",\"industry\":\"农、林、牧、渔业\",\"alias\":\"农林牧渔\",\"sh_stock\":15,\"sz_stock\":26,\"stock\":41},{\"code\":\"B\",\"industry\":\"采矿业\",\"alias\":\"采矿业\",\"sh_stock\":51,\"sz_stock\":26,\"stock\":77},{\"code\":\"C\",\"industry\":\"制造业\",\"alias\":\"制造业\",\"sh_stock\":828,\"sz_stock\":1471,\"stock\":999},{\"code\":\"D\",\"industry\":\"电力、热力、燃气及水生产和供应业\",\"alias\":\"水电煤气\",\"sh_stock\":66,\"sz_stock\":47,\"stock\":113},{\"code\":\"E\",\"industry\":\"建筑业\",\"alias\":\"建筑业\",\"sh_stock\":50,\"sz_stock\":49,\"stock\":99},{\"code\":\"F\",\"industry\":\"批发和零售业\",\"alias\":\"批发零售\",\"sh_stock\":103,\"sz_stock\":68,\"stock\":171},{\"code\":\"G\",\"industry\":\"交通运输、仓储和邮政业\",\"alias\":\"运输仓储\",\"sh_stock\":73,\"sz_stock\":34,\"stock\":107},{\"code\":\"H\",\"industry\":\"住宿和餐饮业\",\"alias\":\"住宿餐饮\",\"sh_stock\":4,\"sz_stock\":7,\"stock\":11},{\"code\":\"I\",\"industry\":\"信息传输、软件和信息技术服务业\",\"alias\":\"信息技术\",\"sh_stock\":60,\"sz_stock\":204,\"stock\":264},{\"code\":\"J\",\"industry\":\"金融业\",\"alias\":\"金融业\",\"sh_stock\":64,\"sz_stock\":27,\"stock\":91},{\"code\":\"K\",\"industry\":\"房地产业\",\"alias\":\"房地产\",\"sh_stock\":74,\"sz_stock\":63,\"stock\":137},{\"code\":\"L\",\"industry\":\"租赁和商务服务业\",\"alias\":\"商务服务\",\"sh_stock\":17,\"sz_stock\":36,\"stock\":53},{\"code\":\"M\",\"industry\":\"科学研究和技术服务业\",\"alias\":\"科学服务\",\"sh_stock\":20,\"sz_stock\":29,\"stock\":49},{\"code\":\"N\",\"industry\":\"水利、环境和公共设施管理业\",\"alias\":\"公共环保\",\"sh_stock\":19,\"sz_stock\":31,\"stock\":50},{\"code\":\"O\",\"industry\":\"居民服务、修理和其他服务业\",\"alias\":\"居民服务\",\"sh_stock\":0,\"sz_stock\":1,\"stock\":1},{\"code\":\"P\",\"industry\":\"教育\",\"alias\":\"教育\",\"sh_stock\":2,\"sz_stock\":1,\"stock\":3},{\"code\":\"Q\",\"industry\":\"卫生和社会工作\",\"alias\":\"卫生\",\"sh_stock\":3,\"sz_stock\":7,\"stock\":10},{\"code\":\"R\",\"industry\":\"文化、体育和娱乐业\",\"alias\":\"文化传播\",\"sh_stock\":26,\"sz_stock\":32,\"stock\":58},{\"code\":\"S\",\"industry\":\"综合\",\"alias\":\"综合\",\"sh_stock\":15,\"sz_stock\":7,\"stock\":22}]";
        }
    }
}
