using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSerializer
{
    public class DelimitedField : BaseObjectField
    {
        public int Position { get; set; }
        public override Type Type { get; set; }

        #region Constructors
        public DelimitedField(int position, string propertyName)
        {
            this.Position = position;
            this.Index = position;
            this.PropertyName = propertyName;
        }

        public DelimitedField(int position, string propertyName, Type type) : this(position, propertyName)
        {
            this.Type = type;
        }

        public DelimitedField(int position, string propertyName, string type) 
            : this(position, propertyName, Type.GetType(type)) { }
        #endregion
    }
}
