using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace Shopshub.Domain
{
    public class Shop : Entity
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
    }
}
