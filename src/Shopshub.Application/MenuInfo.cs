using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Shopshub.Application
{
    public class MenuInfo
    {
        public string Title { get; set; }
        public string Href { get; set; }
        public string Icon { get; set; }
        public string Target { get; set; }
        public MenuInfo[] Child { get; set; }
    }
}
