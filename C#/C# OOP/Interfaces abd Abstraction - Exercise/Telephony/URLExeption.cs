using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class URLExeption : Exception
    {
        private const string ErrorMessage = "Invalid URL!";
        public URLExeption() : base(ErrorMessage)
        {
        }
    }
}
