using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSerializer
{
    public class BaseObjectString<T> where T : BaseObjectField
    {
        public virtual T[] Fields { get; set; }

        public virtual U Deserialize<U>(string[] stringFields) where U : new()
        {
            U item = new U();
            Type type = typeof(U);

            foreach (T field in Fields)
            {
                string fieldString = stringFields[field.Index];
                object fieldValue = field.Type == null ? fieldString : Convert.ChangeType(fieldString, field.Type);
                type.GetProperty(field.PropertyName).SetValue(item, fieldValue, null);
            }

            return item;
        }
    }
}
