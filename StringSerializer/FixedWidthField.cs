using System;
using System.Collections.Generic;
using System.Text;

namespace StringSerializer
{
    public class FixedWidthField
    {
        private Type _type = null;
        
        public int StartingPosition { get; set; }
        public int Length { get; set; }
        public string PropertyName { get; set; }
        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        #region Constructors
        public FixedWidthField() { }

        public FixedWidthField(int startingPosition, int length, string propertyName)
        {
            this.StartingPosition = startingPosition;
            this.Length = length;
            this.PropertyName = propertyName;
        }

        public FixedWidthField(int startingPosition, int length, string propertyName, Type type) 
            : this(startingPosition, length, propertyName)
        {
            this.Type = type;
        }

        public FixedWidthField(int startingPosition, int length, string propertyName, string type)
            : this(startingPosition, length, propertyName, Type.GetType(type)) { }
        #endregion
    }
}
