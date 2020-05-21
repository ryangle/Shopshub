using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Shopshub.Application
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string NickName { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public double Score { get; set; }
        public DateTime Birthday { get; set; }
    }
}
