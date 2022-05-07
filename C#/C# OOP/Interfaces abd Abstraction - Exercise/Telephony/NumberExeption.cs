using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class NumberExeption : Exception
    {
        private const string ErrorMessage = "Invalid number!";
        public NumberExeption() : base(ErrorMessage)
        {
        }
    }
}
