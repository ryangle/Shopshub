using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Application
{
    public class JsonResult<TData>
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public TData Data { get; set; }
    }
}
