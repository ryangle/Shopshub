using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Domain
{
    public class Menu : Entity
    {
        public Guid ParentId { get; set; }
        public string Title { get; set; }
        public string DisplayName { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public string Target { get; set; }
    }
}
