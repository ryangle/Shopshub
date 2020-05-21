using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Domain
{
    public class User : Entity
    {
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public double Wealth { get; set; }
        public double Score { get; set; }
        public int Experience { get; set; }
        public string Comment { get; set; }
        public Role[] Roles { get; set; }
        public string Status { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string QQ { get; set; }
        public string Wechat { get; set; }
        public string Zhifubao { get; set; }
        public string Weibo { get; set; }
        public string Dingding { get; set; }
    }
}
