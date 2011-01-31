using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StringSerializer
{
    public class FixedWidthString
    {
        public FixedWidthField[] Fields;

        #region Constructors
        public FixedWidthString() { }

        public FixedWidthString(FixedWidthField[] fields)
        {
            this.Fields = fields;
        }

        public FixedWidthString(List<FixedWidthField> fields) : this(fields.ToArray()) { }
        #endregion

        public T Deserialize<T>(string objectString) where T : new()
        {
            T item = new T();
            Type type = typeof(T);

            for (int i = 0; i < Fields.Length; i++)
            {
                FixedWidthField field = Fields[i];

                string fieldString = objectString.Substring(field.StartingPosition, field.Length).Trim();
                object fieldValue = field.Type == null ? fieldString : Convert.ChangeType(fieldString, field.Type);
                type.GetProperty(field.PropertyName).SetValue(item, fieldValue, null);
            }

            return item;
        }

        public string Serialize(object obj)
        {
            Type type = obj.GetType();

            FixedWidthField maxField = Fields.First(a => a.StartingPosition == Fields.Max(b => b.StartingPosition));
            string spaceString = new string(' ', maxField.StartingPosition + maxField.Length);
            StringBuilder sb = new StringBuilder(spaceString);

            for (int i = 0; i < Fields.Length; i++)
            {
                FixedWidthField field = Fields[i];

                sb.Remove(field.StartingPosition, field.Length);
                string fieldValue = type.GetProperty(field.PropertyName).GetValue(obj, null).ToString();

                if (fieldValue.Length == field.Length) // If the field is the correct length.
                    sb.Insert(field.StartingPosition, fieldValue);
                else if(fieldValue.Length > field.Length) // If the field is too long.
                    sb.Insert(field.StartingPosition, fieldValue.Remove(field.Length));
                else // If the field is too short, pad.
                    sb.Insert(field.StartingPosition, fieldValue.PadRight(field.Length));
            }

            return sb.ToString();
        }
    }
}
