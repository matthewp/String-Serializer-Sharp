using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringSerializer
{
    public class DelimitedString : BaseObjectString<DelimitedField>
    {
        private bool hasEnclosure = false;

        public override DelimitedField[] Fields { get; set; }
        public char Separator { get; set; }
        public char Enclosure { get; set; }

        #region constructors
        public DelimitedString(char fieldSeparator)
        {
            this.Separator = fieldSeparator;
        }

        public DelimitedString(char fieldSeparator, char fieldEnclosure)
            : this(fieldSeparator)
        {
            this.Enclosure = fieldEnclosure;
            hasEnclosure = true;
        }
        #endregion

        public T Deserialize<T>(string objectString) where T : new()
        {
            string pattern = hasEnclosure ? String.Format(Constants.DelimitedExpressions.WITHENCLOSURES, Separator, Enclosure)
                : String.Format(Constants.DelimitedExpressions.WITHOUTENCLOSURES, Separator);
            string[] stringFields = Regex.Split(objectString, String.Format(pattern, "\""));
            for (int i = 0; i < stringFields.Length; i++) stringFields[i] = stringFields[i].Trim(Enclosure);

            return base.Deserialize<T>(stringFields);
        }
    }
}
