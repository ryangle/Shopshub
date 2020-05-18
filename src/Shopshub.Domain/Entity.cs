using System;
using System.Collections.Generic;
using System.Text;

namespace Shopshub.Domain
{
    public class Entity
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreationTime { get; set; }
        public virtual DateTime UpdateTime { get; set; }

        public virtual Guid? CreatorId { get; set; }
    }
}
