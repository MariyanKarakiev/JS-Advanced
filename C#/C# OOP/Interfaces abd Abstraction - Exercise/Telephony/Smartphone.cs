using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : IBrowsable, ICallable
    {   
        public string Browse(string url)
        {
            if (url.Any(s => char.IsDigit(s)))
            {
                throw new URLExeption();
            }
            
               return $"Browsing: {url}!";
            
        }

        public string Call(string phoneNumToCall)
        {
            if (!phoneNumToCall.All(s => char.IsDigit(s)))
            {
                throw new NumberExeption();
            }

            return $"Calling... {phoneNumToCall}";
        }
    }
}
