using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSerializer
{
    public class BaseObjectField
    {
        public virtual string PropertyName { get; set; }
        public virtual Type Type { get; set; }

        internal int Index { get; set; }
    }
}
