using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Shopshub.Application;
using Shopshub.Web.Models;

namespace Shopshub.Web.Area.Controllers
{
    public class LoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Captcha { get; set; }
    }
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
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult<string>> Login(LoginDto loginDto)
        {
            if (loginDto.Username.Equals("admin") && loginDto.Password.Equals("123456"))
            {
                var claims = new List<Claim>(){
                    new Claim(ClaimTypes.Name,loginDto.Username)
                };

                var userPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, "Customer"));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });

                return new JsonResult<string> { Code = 0, Msg = "" };
            }

            return new JsonResult<string> { Code = -1, Msg = "密码错误" };
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/admin/user/login");
        }
    }
}
