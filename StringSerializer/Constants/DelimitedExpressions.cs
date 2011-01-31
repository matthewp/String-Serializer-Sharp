using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringSerializer.Constants
{
    public class DelimitedExpressions
    {
        public const string WITHENCLOSURES = "{0}(?!(?:[^{1}{0}]|[^{1}]{0}[^{1}])+{1})";
        public const string WITHOUTENCLOSURES = "";
    }
}
