using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Shopshub.Application
{
    public class MenuDto
    {
        public string MenuId { get; set; }
        public string ParentId { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public string Target { get; set; }
        public string Permission { get; set; } = string.Empty;
        public int IsMenu { get; set; }
        public string CreationTime { get; set; }
    }
}
