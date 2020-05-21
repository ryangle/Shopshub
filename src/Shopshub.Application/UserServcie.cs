using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Shopshub.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shopshub.Application
{
    public class UserServcie
    {
        private readonly IConfiguration _configuration;
        private readonly ShopshubContext _shopshubContext;
        public UserServcie(IConfiguration configuration, ShopshubContext shopshubContext)
        {
            _configuration = configuration;
            _shopshubContext = shopshubContext;
        }

        public List<UserDto> GetUsers()
        {
            return _shopshubContext.Users.Select(u => new UserDto
            {
                Id = u.Id.ToString(),
                Username = $"{u.FirstName} {u.LastName}",
                NickName = u.NickName,
                Gender = u.Gender,
                Address = u.Address,
                Score = u.Score,
                Birthday = u.Birthday

            }).ToList();
        }
    }
}
